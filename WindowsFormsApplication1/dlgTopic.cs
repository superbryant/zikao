using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            var url = "http://p.sunlands.com/player-war/live_quizzes/queryQuizzesPaperList.action?userId=236321&paperTypeCode=QUIZZES&systemNumber=PORTAL&field1=283014&quizzesGroupId={0}";
            List<Tuple<string, string>> aa = new List<Tuple<string, string>>();
            DataTable dt = new DataTable();

            dt.Columns.Add("标题", typeof(string));
            dt.Columns.Add("Url", typeof(string));
            for (int i = 1; i < 500; i++)
            {
                var newUrl = string.Format(url, Convert.ToInt32(textBox1.Text) + i);
                using (WebClient wc = new WebClient() { Encoding = System.Text.Encoding.UTF8 })
                {
                    var html = wc.DownloadString(newUrl);
                    var matchTitle = Regex.Match(html, "<h1>(?<b>.*?)</h1>");
                    var title = matchTitle.Groups["b"].Value;
                    if (string.IsNullOrEmpty(title))
                    {
                        continue;
                    }
                    var dr = dt.NewRow();
                    dr["标题"] = title;
                    dr["Url"] = newUrl;
                    dt.Rows.Add(dr);
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
