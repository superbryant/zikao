using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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


        private void button1_Click(object sender, EventArgs e)
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();
            SetDataSource(questionDAL.GetTAttachment(100));
            Thread thread = new Thread(Gather) { IsBackground = true };
            thread.Start();
        }

        private void Gather()
        {
            TAttachmentDAL questionDAL = new TAttachmentDAL();
            int maxQuizzesGroupId = questionDAL.GetMaxTAttachmentId();
            if (maxQuizzesGroupId == 0)
            {
                maxQuizzesGroupId = 1255000;
            }

            var urlFormat = "http://yi.sunlands.com/ent-portal-war/new_pt_uc/lesson_details/ajaxSelectAttachmentList.action?businessId={0}&businessType=1";

            int retry = 0;
            do
            {
                maxQuizzesGroupId++;
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
                        wc.Headers.Add(HttpRequestHeader.Cookie, "JSESSIONID=38298F1AD00A799F7108331942C1779B-n2; examPlan236321=1; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; fun1722780=%3B2971680; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1531663647; examPlan1704494=1; fun1704494=currentWeekLiveDivSub%3B3072154; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1542452419,1542629137,1542638820,1542641037; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1542641037; fun236321=%3B3163162");
                        var html = wc.DownloadString(newUrl);
                        AttachmentJson.Root attachmentList = Newtonsoft.Json.JsonConvert.DeserializeObject<AttachmentJson.Root>(html);

                        if (attachmentList.success == false)
                        {
                            retry++;
                            LogHelper.Ins.InfoFormat("采集失败，标题为空，newUrl：{0}，retry：{1}", newUrl, retry);
                            //continue;
                        }


                        foreach (var item in attachmentList.attachmentList)
                        {
                            retry = 0;
                            TAttachment attachment = new TAttachment()
                            {
                                batchId = item.batchId,
                                businessId = item.businessId,
                                businessType = item.businessType,
                                createTime = item.createTime,
                                creator = item.creator,
                                downloadTimes = item.downloadTimes,
                                fileName = item.fileName,
                                fileSize = item.fileSize,
                                fileUrl = item.fileUrl,
                                id = item.id,
                                record = item.record

                            };

                            EFRepository<TAttachment>.Instance.AddEntity(attachment);
                            LogHelper.Ins.InfoFormat("fileName:{0},maxbusinessId:{1},NewUrl:{2}", item.fileName, item.businessId, newUrl);
                        }

                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Ins.Error(ex);
                }
            } while (retry < 50);

            MessageBox.Show("采集完了");
        }

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


    }
}
