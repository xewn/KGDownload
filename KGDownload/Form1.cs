using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGDownload
{
    public partial class Form1 : Form
    {
        private string defaultPath = Path.Combine(Application.StartupPath, "songs");

        public Form1()
        {
            InitializeComponent();
            txtUrl.Text = @"https://kg2.qq.com/node/play?s=UKOgfHUpwb9PeU6T&shareuid=619a9d8d232f3f883d&topsource=a0_pn201001003_z11_u370862839_l1_t1518142422__";
            txtArtistPage.Text = @"https://node.kg.qq.com/personal?uid=619a9d8d232f3f883d";
            if (!Directory.Exists("songs"))
            {
                Directory.CreateDirectory("songs");
            }
        }

        async private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                btnDownload.Enabled = false;
                labState.Text = "正在下载";
                var info = await DownloadSong(this.txtUrl.Text);
                labState.Text = "正在转码";
                await ConvertToAmr(this.defaultPath, info.Item3, $"{info.Item1}-{info.Item2}.mp3");
                labState.Text = "正在移动";
                await MoveToDisk($"{info.Item1}-{info.Item2}.mp3");
                MessageBox.Show("下载成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                labState.Text = "准备就绪";
                btnDownload.Enabled = true;
            }
        }

        async private Task ConvertToAmr(string applicationPath, string fileName, string targetFilName)
        {
            await Task.Run(() =>
            {
                var args = $"-y -i \"{applicationPath}\\{fileName}\" -acodec mp3 -ar 44100 -ab 75k -ac 2 \"{applicationPath}\\{targetFilName}\"";
                var ffexe = new ProcessStartInfo("ffmpeg.exe", args);
                var proc = new Process();

                ffexe.WindowStyle = ProcessWindowStyle.Hidden;
                ffexe.CreateNoWindow = true;
                proc.StartInfo = ffexe;
                proc.StartInfo.UseShellExecute = false;

                proc.Start();
                proc.WaitForExit();
            });
        }

        async private Task<Tuple<string, string, string>> DownloadSong(string url)
        {
            var artist = string.Empty;
            var title = string.Empty;
            var downloadName = string.Empty;
            await Task.Run(() =>
            {
                var needRepeat = false;
                while (!needRepeat)
                {
                    try
                    {
                        var wc = new WebClient();
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");

                        var html = wc.DownloadString(url);

                        var beginPos = html.IndexOf("window.__DATA__ = ") + 18;
                        var endPos = html.IndexOf("; </script>");

                        var json = html.Substring(beginPos, endPos - beginPos);

                        var jObj = JObject.Parse(json);
                        jObj = JObject.Parse(jObj["detail"].ToString());
                        var music = jObj["playurl"];
                        title = jObj["song_name"].ToString();
                        artist = jObj["kg_nick"].ToString();

                        downloadName = $"{artist}-{jObj["song_name"].ToString()}.m4a";
                        wc.DownloadFile(music.ToString(), Path.Combine(this.defaultPath, downloadName));
                        needRepeat = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            return Tuple.Create(artist, title, downloadName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        async private Task MoveToDisk(string fileName)
        {
            await Task.Run(() =>
            {
                var copied = false;
                foreach (var driver in DriveInfo.GetDrives())
                {
                    if (File.Exists(Path.Combine(driver.Name, "songs.sav")))
                    {
                        var time = 0;
                        var back = string.Empty;
                        while (File.Exists(
                            Path.Combine(
                                driver.Name,
                                $"{Path.GetFileNameWithoutExtension(fileName)}{back}{Path.GetExtension(fileName)}")))
                        {
                            time++;
                            back = $"_({time})";
                        }
                        File.Copy(
                            Path.Combine(
                                this.defaultPath,
                                fileName),
                            Path.Combine(
                                driver.Name,
                                $"{Path.GetFileNameWithoutExtension(fileName)}{back}{Path.GetExtension(fileName)}"));
                        copied = true;
                    }
                }
                if (!copied)
                {
                    ProcessStartInfo psi = new ProcessStartInfo("E xplorer.exe");
                    psi.Arguments = "/e ," + this.defaultPath + @"\";
                    Process.Start(psi);
                }
            });
        }

        async private Task ArtistPage(string url)
        {
            var songList = new List<JToken>();
            labPercent.Text = "正在解析";
            await Task.Run(() =>
            {
                var wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");

                var artHtml = wc.DownloadString(url);
                artHtml = artHtml.Substring(artHtml.IndexOf("<span class=\"my_show__name\">")).Replace("<span class=\"my_show__name\">", "");
                var artist = artHtml.Substring(0, artHtml.IndexOf("</span>"));

                var uid = url.Substring(url.IndexOf("uid=")).Replace("uid=", "");
                var pageIndex = 1;
                var hasMore = true;
                while (hasMore)
                {
                    var reqUrl = $@"https://node.kg.qq.com/cgi/fcgi-bin/kg_ugc_get_homepage?jsonpCallback=callback_1&g_tk=5381&outCharset=utf-8&format=jsonp&type=get_ugc&start={pageIndex}&num=10&touin=&share_uid={uid}&g_tk_openkey=5381&_=1519865593089";
                    var json = wc.DownloadString(reqUrl).Replace("callback_1(", "");
                    json = json.Remove(json.Length - 1);

                    var jObj = JObject.Parse(json)["data"];
                    if (jObj["has_more"].ToString() == "0")
                    {
                        hasMore = false;
                    }

                    var jArr = JArray.Parse(jObj["ugclist"].ToString());
                    songList.AddRange(jArr);

                    pageIndex++;
                }
                int allNum = songList.Count * 3;
                int doneNum = 0;

                #region Parallel

                Parallel.ForEach(songList, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, async (item) =>
                    {
                        var mp3Url = $"https://node.kg.qq.com/play?s={item["shareid"].ToString()}&g_f=personal";
                        var downloadName = $"{artist}-{item["title"]}.m4a";
                        var targetName = $"{artist}-{item["title"]}.mp3";

                        await DownloadSong(mp3Url);
                        Interlocked.Increment(ref doneNum);
                        labPercent.Text = (doneNum * 100 / allNum) + "%";

                        await ConvertToAmr(this.defaultPath, downloadName, targetName);
                        Interlocked.Increment(ref doneNum);
                        labPercent.Text = (doneNum * 100 / allNum) + "%";

                        await MoveToDisk(targetName);
                        Interlocked.Increment(ref doneNum);
                        labPercent.Text = (doneNum * 100 / allNum) + "%";
                    });

                #endregion Parallel
            });
        }

        async private void btnPersonDownload_Click(object sender, EventArgs e)
        {
            this.btnPersonDownload.Enabled = false;
            await ArtistPage(this.txtArtistPage.Text);
            this.btnPersonDownload.Enabled = true;
        }
    }
}