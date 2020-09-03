using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Regex007GroupDialog : Form
    {
        public Regex007GroupDialog()
        {
            InitializeComponent();
        }

        public Regex007GroupDialog(BuildType bt)
            : this()
        {
            buildType = bt;
        }

        private void btnBuildHtml_Click(object sender, EventArgs e)
        {
            //var html = txtHtml.Text;
            if (string.IsNullOrEmpty(txtHtml.Text)) {
                MessageBox.Show("文件不能空");
                return;
            }
            if (File.Exists(txtHtml.Text) == false)
            {
                MessageBox.Show("文件不存在");
                return;
            }
           var html= File.ReadAllText(txtHtml.Text,Encoding.UTF8);

            var matches = Regex.Matches(html, @"class=""van-cell__title""><span.*?>(?<author>.*?)</span>[\s\S]*?累计打卡 (?<times>.*?) 次[\s\S]*?class=""content"">(?<content>[\s\S]*?)</span>[\s\S]*?class=""van-col"">(?<pubDate>.*?)</div>");
            HtmlBuilder hb = new HtmlBuilder();
              EFRepository<OO7_Group> instance=new EFRepository<OO7_Group> ();
            foreach (Match match in matches)
            {
                try
                {
                    var author = match.Groups["author"].Value;
                    var times = match.Groups["times"].Value;
                    var content = match.Groups["content"].Value;
                    var pubDate = DateTime.Parse(match.Groups["pubDate"].Value);
                    if (buildType == BuildType.yestoday)
                    {
                        var start = DateTime.Now.Date.AddDays(-1);
                        var end = DateTime.Now.Date;
                        if (pubDate < start || pubDate >= end)
                        {
                            continue;
                        }
                    }
                    instance.AddEntity(new OO7_Group()
                    {
                        Author = author,
                        Content = content,
                        CreateDate = DateTime.Now,
                        PubDate = pubDate,
                        Times = int.Parse(times)

                    });

                    hb.AddBodyItem(string.Format("{0},{1},{2}：", pubDate, times, author), content);
                }
                catch (Exception ex)
                {
                    LogHelper.Ins.Error(ex);
                }
            }

            var bhtml = hb.Build();

            this.Close();
        }

        BuildType buildType = BuildType.all;
    }
}
public enum BuildType
{
    all = 1,
    yestoday = -1
}