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

namespace WindowsFormsApplication1
{
    public partial class dlgTopic : Form
    {
        public dlgTopic()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            SetDataSource(questionDAL.GetQuestion(100));
            Thread thread = new Thread(Gather) { IsBackground = true };
            thread.Start();
        }

        private void Gather()
        {
            QuestionDAL questionDAL = new QuestionDAL();
            int maxQuizzesGroupId = questionDAL.GetMaxQuestionId();
            if (maxQuizzesGroupId == 0)
            {
                maxQuizzesGroupId = 10000;
            }
            //Request URL: http://p.sunlands.com/player-war/live_quizzes/queryQuizzesPaperList.action?userId=236321&paperTypeCode=QUIZZES&systemNumber=PORTAL&field1=285346&quizzesGroupId=27763

            var urlFormat = "http://p.sunlands.com/player-war/live_quizzes/queryQuizzesPaperList.action?userId=236321&paperTypeCode=QUIZZES&systemNumber=PORTAL&field1=283014&quizzesGroupId={0}";

            int retry = 0;
            do
            {
                maxQuizzesGroupId++;
                var newUrl = string.Format(urlFormat, maxQuizzesGroupId);
                try
                {
                    using (WebClient wc = new WebClient() { Encoding = System.Text.Encoding.UTF8 })
                    {
                        var html = wc.DownloadString(newUrl);
                        var matchTitle = Regex.Match(html, "<h1>(?<b>.*?)</h1>");
                        var title = matchTitle.Groups["b"].Value;
                        if (string.IsNullOrEmpty(title) && maxQuizzesGroupId > 27763)
                        {
                            retry++;
                            LogHelper.Ins.InfoFormat("采集失败，标题为空，newUrl：{0}，retry：{1}", newUrl, retry);
                            //continue;
                        }

                        if (string.IsNullOrEmpty(title))
                        {
                            continue;
                        }
                        retry = 0;
                        Question qustion = new Question()
                        {
                            CreateDate = DateTime.Now,
                            NewUrl = newUrl,
                            QuizzesGroupId = maxQuizzesGroupId.ToString(),
                            Title = title
                        };

                        EFRepository<Question>.Instance.AddEntity(qustion);
                        LogHelper.Ins.InfoFormat("title:{0},maxQuizzesGroupId:{1},NewUrl:{2}", title, maxQuizzesGroupId, newUrl);
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
            QuestionDAL questionDAL = new QuestionDAL();
            SetDataSource(questionDAL.GetQuestion(txtSearch.Text, 500));
        }
        List<Question> _list;
        private void SetDataSource(List<Question> list)
        {
            _list = list;
            DataTable dt = new DataTable();
            dt.Columns.Add("quizzesId", typeof(string));
            dt.Columns.Add("标题", typeof(string));
            dt.Columns.Add("次数", typeof(int));
            dt.Columns.Add("状态", typeof(bool));
            dt.Columns.Add("最后", typeof(string));
            dt.Columns.Add("Url", typeof(string));

            foreach (var item in list)
            {
                var dr = dt.NewRow();
                dr["quizzesId"] = item.QuizzesGroupId;
                dr["标题"] = item.Title;
                dr["次数"] = item.AnswerCount.HasValue ? item.AnswerCount.Value : 0;
                dr["状态"] = item.Comp.HasValue && item.Comp.Value;
                dr["最后"] = item.UpdateDate.HasValue ? item.UpdateDate.Value.ToString("MM-dd HH:mm:ss") : "";
                dr["Url"] = item.NewUrl;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            Application.DoEvents();
            AddRowHeader();
        }
        private void SetDataSourceForGood(List<Question> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("quizzesId", typeof(string));
            dt.Columns.Add("标题", typeof(string));
            dt.Columns.Add("状态", typeof(bool));
            dt.Columns.Add("Url", typeof(string));

            foreach (var item in list)
            {
                var dr = dt.NewRow();
                dr["quizzesId"] = item.QuizzesGroupId;
                dr["标题"] = item.Title;
                dr["状态"] = item.Comp.HasValue && item.Comp.Value;
                dr["Url"] = string.Format("https://ay2tda.mlinks.cc/Aec9?pagedetail=homework&unitidstr=-1&param={0}", item.QuizzesGroupId);
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
                Goto(url);
            }
        }

        private void Goto(string url)
        {
            try
            {

                this.webBrowser1.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LogHelper.Ins.Error(ex);
            }
        }

        private void tsmiComplected_Click(object sender, EventArgs e)
        {
            QuestionDAL questionDAL = new QuestionDAL();

            var qzId = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            questionDAL.UpdateComplected(qzId);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {

            Goto(txtUrl.Text);
            try
            {
                //更新，count,更新时间
                var match = Regex.Match(txtUrl.Text, "quizzesGroupId=(?<b>.+)");
                if (match.Success && _list != null)
                {
                    var quizzesGroupId = match.Groups["b"].Value;
                    var model = _list.FirstOrDefault(f => f.QuizzesGroupId == quizzesGroupId);
                    if (model != null)
                    {
                        model.UpdateDate = DateTime.Now;
                        if (model.AnswerCount == null)
                        {
                            model.AnswerCount = 0;
                        }
                        model.AnswerCount++;
                        model.NewUrl = txtUrl.Text;
                        EFRepository<Question> dal = new EFRepository<Question>();
                        var result = dal.UpdateEntity(model);
                        LogHelper.Ins.InfoFormat("{0}_{1}，更新回答次数的结果：{2}", quizzesGroupId, model.Title, result);
                    }
                }
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

        private void btnSearchForGood_Click(object sender, EventArgs e)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            SetDataSourceForGood(questionDAL.GetQuestion(txtSearch.Text, 500));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string format = @"<!DOCTYPE html>
<html>
<head>
<meta http-equiv=""X-UA-Compatible"" content=""IE=Edge"" />
<meta http-equiv=""content-type"" content=""text/html;charset=utf-8"" />
<meta property=""wb:webmaster"" content=""3aababe5ed22e23c"" />
<meta name=""referrer"" content=""always"" />
<title>{0}</title>
<body>

<div id=""anttongji"">
{1}
</div>
</body>

</html>
";
            string lineFormat = @"<p><a href=""{0}"" target=""_blank"">{1}</a></p>";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //    dr["标题"] = item.Title;
                //dr["状态"] = item.Comp.HasValue && item.Comp.Value;
                //dr["Url"] 

                string line =string.Format(lineFormat,row.Cells["Url"].Value, row.Cells["标题"].Value );
                sb.AppendLine(line);
            }
            var rootDir = @"F:\自考\export";
            var fileName = txtSearch.Text + dataGridView1.Rows.Count + "套题-" + DateTime.Now.ToString("yyyy-MM-dd");
            var s = sb.ToString();
            var content = string.Format(format, fileName, s);
            var fileNamePath = Path.Combine(rootDir, txtSearch.Text, fileName + ".html");
            var dir = Path.GetDirectoryName(fileNamePath);
            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
          
            try
            {
                File.WriteAllText(fileNamePath, content, Encoding.UTF8);
                System.Diagnostics.Process.Start(fileNamePath);
            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }


    }
}
