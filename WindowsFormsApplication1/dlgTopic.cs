using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            dataGridView1.DataSource = questionDAL.GetQuestion(100);
            Thread thread = new Thread(Gather) {  IsBackground=true};
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
                        if (string.IsNullOrEmpty(title) && maxQuizzesGroupId>27763)
                        {
                            retry++;
                            LogHelper.Ins.InfoFormat("采集失败，标题为空，newUrl：{0}，retry：{1}", newUrl,retry);
                            //continue;
                        }
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
            dataGridView1.DataSource = questionDAL.GetQuestion(textBox1.Text, 100);
        }
    }
}
