using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1
{
    public partial class dlgAttachment : Form
    {
        public dlgAttachment()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        System.Threading.Semaphore _Semaphore = new Semaphore(50, 50);

        private void button1_Click(object sender, EventArgs e)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();
            SetDataSource(questionDAL.GetTAttachment(100));
            int maxQuizzesGroupId = questionDAL.GetMaxTAttachmentId();
            if (maxQuizzesGroupId == 0)
            {

            } maxQuizzesGroupId = 5110063;
            int retry = 0;
            do
            {
                maxQuizzesGroupId++;

       _Semaphore.WaitOne();
                Thread thread = new Thread(Gather);
                thread.Start(maxQuizzesGroupId);
         
            } while (retry < 50);
        }
        CookieContainer cookies = new CookieContainer();



        private void Gather(object obj)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();

            //maxQuizzesGroupId = 1103285;
            var urlFormat = "http://player.sunlands.com/player-war/attachment/getAttachmentList?teachUnitId={0}";

            //var urlFormat = "http://yi.sunlands.com/ent-portal-war/new_pt_uc/lesson_details/ajaxSelectAttachmentList.action?businessId={0}&businessType=1";

            var maxQuizzesGroupId = obj.ToString();

            var newUrl = string.Format(urlFormat, maxQuizzesGroupId);
            try
            {
                using (WebClient wc = new WebClient() { Encoding = System.Text.Encoding.UTF8 })
                {
                    //                        wc.cookie:wc
                    //                     uest Cookies					413				
                    //Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f	1542641037	N/A	N/A	N/A	53				
                    //Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f	1542452419,1542629137,1542638820,1542641037	N/A	N/A	N/A	85				
                    //Hm_lvt_3b92ef8db1054c41ec24e09ecd765369	1531663647	N/A	N/A	N/A	52				
                    //JSESSIONID	38298F1AD00A799F7108331942C1779B-n2	N/A	N/A	N/A	48				
                    //examPlan1704494	1	N/A	N/A	N/A	19				
                    //examPlan236321	1	N/A	N/A	N/A	18				
                    //fun1704494	currentWeekLiveDivSub%3B3072154	N/A	N/A	N/A	44				
                    //fun1722780	%3B2971680	N/A	N/A	N/A	23				
                    //fun236321	%3B3163162	N/A	N/A	N/A	20				
                    //userIdentify	7ee4e929-17a2-4185-9cae-7340607523c6	N/A	N/A	N/A	51
                    wc.Headers.Add(HttpRequestHeader.Referer,"http://player.sunlands.com/room/");
                    wc.Headers.Add(HttpRequestHeader.Cookie, "userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1577892291,1578127896,1578131976,1578263611; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578263611; pluser=NmVkMTZhZmItNDg0NC00OTc0LTgzMGEtNDRhZjcwMGQxN2U2");
                    var html = wc.DownloadString(newUrl);
                    AttachmentJson.Root attachmentList = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentJson.Root>(html);

                    //if (attachmentList.success == false)
                    //{
                    //    retry++;
                    //    LogHelper.Ins.InfoFormat("采集失败，标题为空，newUrl：{0}，retry：{1}", newUrl, retry);
                    //    //continue;
                    //}


                    lock (_lockObj)
                    {
                        foreach (var item in attachmentList.resultMessage)
                        {
                            //retry = 0;
                            TAttachment attachment = new TAttachment()
                            {
                                //batchId = item.batchId,
                                businessId =Convert.ToInt64( maxQuizzesGroupId),
                                //businessType = item.businessType,
                                createTime = DateTime.Now,
                                //creator = item.creator,
                                //downloadTimes = item.downloadTimes,
                                fileName = item.docName,
                                fileSize = item.docSize,
                                fileUrl = item.docDownloadUrl,
                                id =item.docId,
                                //record = item.record,
                                //prefix = item.prefix
                            };

                            EFRepository<TAttachment>.Instance.AddEntity(attachment);
                            LogHelper.Ins.InfoFormat("fileName:{0},maxbusinessId:{1},NewUrl:{2}", item.docName, attachment.businessId, newUrl);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
            }


            //MessageBox.Show("采集完了");
            _Semaphore.Release();
        }
        private static object _lockObj = new object();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();
            SetDataSource(questionDAL.GetTAttachment(txtSearch.Text, 500));
        }
        List<TAttachment> _list;
        private void SetDataSource(List<TAttachment> list)
        {
            _list = list;
            DataTable dt = new DataTable();
            dt.Columns.Add("businessId", typeof(string));
            dt.Columns.Add("标题", typeof(string));
            dt.Columns.Add("downloadTimes", typeof(int));
            dt.Columns.Add("fileUrl", typeof(string));
            foreach (var item in list)
            {
                var dr = dt.NewRow();
                dr["businessId"] = item.businessId;
                dr["标题"] = item.fileName;
                dr["downloadTimes"] = item.downloadTimes;
                dr["fileUrl"] = item.fileUrl;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            Application.DoEvents();
            AddRowHeader();
        }


        private void AddRowHeader()
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow r = this.dataGridView1.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", i + 1);
            }
            this.dataGridView1.Refresh();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var url = txtUrl.Text = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
            }
        }


        private void tsmiComplected_Click(object sender, EventArgs e)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();

            var qzId = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            questionDAL.UpdateComplected(qzId);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {


            try
            {
                //更新，count,更新时间


                //var model = _list.FirstOrDefault(f => f.QuizzesGroupId == quizzesGroupId);
                //if (model != null)
                //{
                //    model.UpdateDate = DateTime.Now;
                //    if (model.AnswerCount == null)
                //    {
                //        model.AnswerCount = 0;
                //    }
                //    model.AnswerCount++;
                //    model.NewUrl = txtUrl.Text;
                //    EFRepository<TAttachment> dal = new EFRepository<TAttachment>();
                //    var result = dal.UpdateEntity(model);
                //    LogHelper.Ins.InfoFormat("{0}_{1}，更新回答次数的结果：{2}", quizzesGroupId, model.Title, result);
                //}

            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            AddRowHeader();
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            var url = string.Format("http://static.sunlands.com{0}", txtUrl.Text);
            using (WebClient wc = new WebClient() { Encoding = System.Text.Encoding.UTF8 })
            {
                var fileName = Path.Combine(@"F:\自考\Attachment", Path.GetFileName(txtUrl.Text));
                wc.DownloadFile(url, fileName);
            }
        }

        private void btnGatherLession_Click(object sender, EventArgs e)
        {
            TeachUnitDAL teachUnitDAL = new TeachUnitDAL();
            //SetDataSource(questionDAL.GetTAttachment(100));
            int maxQuizzesGroupId = teachUnitDAL.GetMaxTeachUnitId();
            if (maxQuizzesGroupId == 0)
            {
                maxQuizzesGroupId = 1103286;
            }
            int retry = 0;
            do
            {
                maxQuizzesGroupId++;
                //GatherLession(maxQuizzesGroupId);
                _Semaphore.WaitOne();
                Thread thread = new Thread(GatherLession);
                thread.Start(maxQuizzesGroupId);
               
            } while (retry < 50);
        }

        private void GatherLession(object obj)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();


            var urlFormat = "http://yi.sunlands.com/ent-portal-war/pt_uc/live/playerPage.action?unitId={0}&playerType=replay";

            var maxQuizzesGroupId = obj.ToString();

            var newUrl = string.Format(urlFormat, maxQuizzesGroupId);
            try
            {
                var url = GetLocation(newUrl, Encoding.UTF8);

                var html = GetHtml(url, Encoding.UTF8);
                var userId = Regex.Match(html, @"id=""userId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var teachId = Regex.Match(html, @"id=""teachId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                if (string.IsNullOrEmpty(teachId))
                {
                    throw new ArgumentNullException("teachId");
                }
                var encryptStr = Regex.Match(html, @"id=""encryptStr"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var timeMillis = Regex.Match(html, @"id=""timeMillis"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var className = Regex.Match(html, @"id=""className"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var teachUnitName = Regex.Match(html, @"id=""teachUnitName"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var attendClassTime = Regex.Match(html, @"id=""attendClassTime"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var playWebCastId = Regex.Match(html, @"id=""playWebCastId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var provider = Regex.Match(html, @"id=""provider"" value=""(?<b>.*?)""/>").Groups["b"].Value;
                var webroot = Regex.Match(html, @"id=""webroot"" value=""(?<b>.*?)""/>").Groups["b"].Value;



                //if (attachmentList.success == false)
                //{
                //    retry++;
                //    LogHelper.Ins.InfoFormat("采集失败，标题为空，newUrl：{0}，retry：{1}", newUrl, retry);
                //    //continue;
                //}
                LogHelper.Ins.InfoFormat("teachId:{0},teachUnitName:{1},url:{2}", teachId, teachUnitName, newUrl);

                lock (_lockObj)
                {

                    TeachUnit attachment = new TeachUnit()
                    {
                        TeachId = Convert.ToInt32(teachId),
                        AttendClassTime = attendClassTime,
                        ClassName = className,
                        EncryptStr = encryptStr,
                        PlayWebCastId = playWebCastId,
                        Provider = provider,
                        TeachUnitName = teachUnitName,
                        TimeMillis = timeMillis,
                        UserId = userId,
                        Webroot = webroot,
                        CreateTime = DateTime.Now
                    };

                    EFRepository<TeachUnit>.Instance.AddEntity(attachment);



                }
            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
            }


            //MessageBox.Show("采集完了");
            _Semaphore.Release();
        }


      

        private TeachUnit GetModelV1(string url)
        {
            var html = GetHtml(url, Encoding.UTF8);
            var userId = Regex.Match(html, @"id=""userId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var teachId = Regex.Match(html, @"id=""teachId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            if (string.IsNullOrEmpty(teachId))
            {
                throw new ArgumentNullException("teachId");
            }
            var encryptStr = Regex.Match(html, @"id=""encryptStr"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var timeMillis = Regex.Match(html, @"id=""timeMillis"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var className = Regex.Match(html, @"id=""className"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var teachUnitName = Regex.Match(html, @"id=""teachUnitName"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var attendClassTime = Regex.Match(html, @"id=""attendClassTime"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var playWebCastId = Regex.Match(html, @"id=""playWebCastId"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var provider = Regex.Match(html, @"id=""provider"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var webroot = Regex.Match(html, @"id=""webroot"" value=""(?<b>.*?)""/>").Groups["b"].Value;
            var teachUnit = new TeachUnit()
                 {
                     TeachId = Convert.ToInt32(teachId),
                     AttendClassTime = attendClassTime,
                     ClassName = className,
                     EncryptStr = encryptStr,
                     PlayWebCastId = playWebCastId,
                     Provider = provider,
                     TeachUnitName = teachUnitName,
                     TimeMillis = timeMillis,
                     UserId = userId,
                     Webroot = webroot,
                     CreateTime = DateTime.Now
                 };
            return teachUnit;
        }

        private void GatherLessionV2(object obj)
        {
             
            var urlFormat = "http://yi.sunlands.com/ent-portal-war/pt_uc/live/playerPage.action?unitId={0}&playerType=replay";

            var maxQuizzesGroupId = obj.ToString();
      
            var newUrl = string.Format(urlFormat, maxQuizzesGroupId);
            try
            {
                var url = GetReplayLocation(newUrl, Encoding.UTF8);

        
                TeachUnit attachment=null;
                if (url.Contains("login"))
                {
                    attachment = GetModelV2(maxQuizzesGroupId, url);
                }
                else
                {
                    attachment = GetModelV1(url);
                }

                if (attachment != null)
                {
                    lock (_lockObj)
                    {

                        EFRepository<TeachUnit>.Instance.AddEntity(attachment);


                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
            }


            //MessageBox.Show("采集完了");
            _Semaphore.Release();
        }

        private TeachUnit GetModelV2(string maxQuizzesGroupId, string url)
        {
            var encryptUrl = System.Web.HttpUtility.UrlDecode(url);
            var loginUrl =GetLoginLocation(url, Encoding.UTF8);

            var toTechUrl = GetToTechLocation(loginUrl, Encoding.UTF8);

            var roomHtml = GetHtml(toTechUrl, Encoding.UTF8);
            var encryptStr = Regex.Match(encryptUrl, "encryptStr=(?<b>.*?)&").Groups["b"].Value;
            var lessionUrl = string.Format("http://player.sunlands.com/player-war/player/token?sign={0}&teachUnitId={1}", encryptStr, maxQuizzesGroupId);
            var lessionHtml = GetHtml(lessionUrl, Encoding.UTF8);
            var lession = Newtonsoft.Json.JsonConvert.DeserializeObject<LessionJson.Root>(lessionHtml);


            if (lession == null)
            {
                throw new ArgumentNullException("lession");
            }

            if (lession.rs != 1 )
            {
                throw new ArgumentNullException(string.Format("lession,errorCode:{0},errorMessage:{1}", lession.errorCode, lession.errorMessage));
            }
            if (lession.resultMessage == null)
            {
                throw new ArgumentNullException(string.Format("lession,errorCode:{0},errorMessage:{1}", lession.errorCode, lession.errorMessage));
            }

            if (lession.resultMessage.teachUnitId == null)
            {
                throw new ArgumentNullException(string.Format("lession,errorCode:{0},errorMessage:{1}", lession.errorCode, lession.errorMessage));
            }

            LogHelper.Ins.InfoFormat("teachId:{0},teachUnitName:{1},url:{2}", lession.resultMessage.teachUnitId, lession.resultMessage.teachUnitName, lessionUrl);

            TeachUnit attachment = new TeachUnit()
            {
                TeachId = lession.resultMessage.teachUnitId.Value,
                AttendClassTime = lession.resultMessage.liveData,
                ClassName = lession.resultMessage.liveRoomId,
                EncryptStr = encryptStr,
                PlayWebCastId = lession.resultMessage.teachUnitStartTime + "",
                Provider = lession.resultMessage.liveProvider,
                TeachUnitName = lession.resultMessage.teachUnitName,
                TimeMillis = lession.resultMessage.teachUnitEndTime + "",
                //UserId = lession.resultMessage.userId,
                Webroot = lession.resultMessage.teachUnitStatus + "",
                CreateTime = DateTime.Now
            };
            return attachment;
        }
        public string GetToTechLocation(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            req.Headers.Add(HttpRequestHeader.Cookie, "userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1577622502,1577891744,1577892291,1578127896; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578127896");
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
            //req.Referer = "http://navi.cnki.net/knavi/JournalDetail?pcode=CJFD&pykm=DSUZ";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);
                return rep.Headers["Location"];

            }

        }
        public string GetReplayLocation(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            req.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=C1891025FB04E0AF3D09551872407769-n2; examPlan236321=1; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; examPlan1704494=1; fun1704494=%3B3072154; fun10284270=reviewDivSub%3B4614772; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; fun236321=keyComplainDivSub%3B5249170; _slog_uid=BD50A4628F46BDBF532062E7218033D7; compatible236321=1; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1577622502,1577891744,1577892291,1578127896; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578127896");
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
            //req.Referer = "http://navi.cnki.net/knavi/JournalDetail?pcode=CJFD&pykm=DSUZ";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);
                return rep.Headers["Location"];

            }

        }
        public string GetLoginLocation(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            //req.Headers.Add(HttpRequestHeader.Cookie, "userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; CASUAE=nj7t7iNJHeM0lBC3aX7zmQ; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; loginName=15914786169; loginPwd=MyEclipseachilles; rememberMeFlag=1; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1576674218,1577622502,1577891744,1577892291; JSESSIONID=8BD5C23D8FF7AF81EB095CDC2B2B18BB; CASTGC=TGT-1715396-zsBsanET3Qs2vhqcAAL21nEaKyUFZHbI3jibDBWCmhdzsdHNBf-cas; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578060204");
            req.Headers.Add(HttpRequestHeader.Cookie, "userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; CASUAE=nj7t7iNJHeM0lBC3aX7zmQ; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; loginName=15914786169; loginPwd=MyEclipseachilles; rememberMeFlag=1; _slog_uid=BD50A4628F46BDBF532062E7218033D7; JSESSIONID=3042BC3FBACAE98332716F53419D9B38; CASTGC=TGT-1756983-g5a0tje0DLQ7GEKk3cjQfwUxkYHNHTbk2kSl6XMlxIi7c6d90T-cas; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1577622502,1577891744,1577892291,1578127896; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578127896");
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
            //req.Referer = "http://navi.cnki.net/knavi/JournalDetail?pcode=CJFD&pykm=DSUZ";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);
                return rep.Headers["Location"];

            }

        }
        public string GetLocation(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            req.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=D5DE0AF9862B69FBDBE58AAA084D6668-n1; examPlan236321=1; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; examPlan1704494=1; fun1704494=%3B3072154; fun10284270=reviewDivSub%3B4614772; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; fun236321=keyComplainDivSub%3B5249170; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1576674218,1577622502,1577891744,1577892291; compatible236321=1; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578060204");
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
            //req.Referer = "http://navi.cnki.net/knavi/JournalDetail?pcode=CJFD&pykm=DSUZ";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);
                return rep.Headers["Location"];

            }

        }

        public string GetNoCookieLocation(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
           
            //req.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=CF4D8E62D65843F84C5F52A981FF01BC-n2; examPlan236321=1; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; examPlan1704494=1; fun1704494=%3B3072154; fun10284270=reviewDivSub%3B4614772; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; fun236321=keyComplainDivSub%3B5249170; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1576674218,1577622502,1577891744,1577892291; compatible236321=1; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1577978493");
            req.AllowAutoRedirect = false;
            req.CookieContainer = cookies;
            //req.Referer = "http://navi.cnki.net/knavi/JournalDetail?pcode=CJFD&pykm=DSUZ";
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);
                return rep.Headers["Location"];

            }

        }



        public string GetTestHtml(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "application/json, text/plain, */*";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            //req.Referer="http://player.sunlands.com/room/";
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
            req.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=D5DE0AF9862B69FBDBE58AAA084D6668-n1; examPlan236321=1; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; examPlan1704494=1; fun1704494=%3B3072154; fun10284270=reviewDivSub%3B4614772; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; fun236321=keyComplainDivSub%3B5249170; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1576674218,1577622502,1577891744,1577892291; compatible236321=1; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578060204");
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            using (var fs = rep.GetResponseStream())
            {
                cookies.Add(rep.Cookies);

                //using (System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress))
                //{
                string html = "";
                StreamReader sr = new StreamReader(fs);
                html = sr.ReadToEnd();
                sr.Close();
                return html;
                //}
            }

        }

        public string GetHtml(string url, Encoding encoding)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "application/json, text/plain, */*";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
            req.Method = WebRequestMethods.Http.Get;
            req.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            req.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6");
            //req.Referer="http://player.sunlands.com/room/";
            req.AllowAutoRedirect = false;
            //req.CookieContainer = cookies;
                //req.Headers.Add(HttpRequestHeader.Cookie, "userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1572039528,1573349105; _slog_uid=BD50A4628F46BDBF532062E7218033D7; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1576674218,1577622502,1577891744,1577892291; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1578060204; pluser=OGQ1OWViYTItM2I3YS00ODA0LWEwZWItOGYyNDY2NmQ2MmZm");
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
           return GetResponseBody(rep);

        }

        public string GetResponseBody(HttpWebResponse response)
        {
            string responseBody = string.Empty;
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            return responseBody;
        }

        private void btnGatherLessionV2_Click(object sender, EventArgs e)
        {
            //GatherLessionV2(1);
            //return;
            TeachUnitDAL teachUnitDAL = new TeachUnitDAL();
            //SetDataSource(questionDAL.GetTAttachment(100));
            int maxQuizzesGroupId = teachUnitDAL.GetMaxTeachUnitId();
            if (maxQuizzesGroupId == 0)
            {
                maxQuizzesGroupId = 1103286;
            }
            int retry = 0;
            do
            {
                maxQuizzesGroupId++;
                
                _Semaphore.WaitOne();
                Thread thread = new Thread(GatherLessionV2);
                thread.Start(maxQuizzesGroupId);
         
            } while (retry < 50);
        }

    }
}
