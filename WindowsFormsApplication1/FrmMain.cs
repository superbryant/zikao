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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Controls;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        bool loding = true;
        void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            ProtectEye(Controls);
            loding = false;
            this.cboChapter.SelectedIndexChanged += new System.EventHandler(this.cboChapter_SelectedIndexChanged);
            this.cboSection.SelectedIndexChanged += new System.EventHandler(this.cboSection_SelectedIndexChanged);
            this.cboSubject.SelectedIndexChanged += new System.EventHandler(this.cboSubject_SelectedIndexChanged);
        }

        private void LoadData()
        {
            //加载考期
            var issues = EFRepository<TIssue>.Instance.LoadEntities(f => f.FStatus == true);
            var issue = issues.FirstOrDefault();
            if (issue == null)
                return;
            txtIssue.Text = issue.Issue;
            var issueSubjects = EFRepository<TIssueSubject>.Instance.LoadEntities(f => f.Issue == issue.Issue);
            var issueSubject = issueSubjects.FirstOrDefault();
            if (issueSubject == null)
                return;
            var allSubject = EFRepository<Subject>.Instance.LoadEntities();
            if (allSubject.Count == 0)
                return;
            var subjects = allSubject.Where(s => issueSubjects.Select(f => f.Code).Contains(s.Code));

            if (subjects.Count() == 0)
                return;

            cboSubject.DataSource = new BindingList<Subject>(subjects.ToList());
            cboSubject.ValueMember = "Code";
            cboSubject.DisplayMember = "Name";
            cboSubject.SelectedItem = subjects.OrderByDescending(f => f.UpdateDate).FirstOrDefault();


            LoadChild(allSubject);

            //加载科目
            //加载章
            //加载节

            InitialWebBrowser();
        }

        private void InitialWebBrowser()
        {
            this.webBrowser1.Navigate("about:blank");

            this.webBrowser1.Document.Write(
              @"<html  >

<head>
<meta http-equiv=Content-Type content=""text/html; charset=gb2312""> 
<style>
body{
font-size: 20px;
    font-family: 宋体;
}
table {
    border:1px solid #d9d9d9;
}

td {
    border:1px solid #d9d9d9;
    padding:3px;
}

/* ***************************************
** Diff related styles
*****************************************/

ins {
	background-color: #cfc;
	text-decoration:inherit;

}

del {
	color: #999;
	background-color:#FEC8C8;
}

ins.mod {
    background-color: #FFE1AC;
}
</style>

</head>

<body   >
 

</body>

</html>");

        }



        private void LoadChild(IList<Subject> allSubject)
        {
            if (allSubject == null)
            {
                allSubject = EFRepository<Subject>.Instance.LoadEntities();
            }
            var chapters = allSubject.Where(s => s.ParentCode == (cboSubject.SelectedItem as Subject).Code);
            cboChapter.DataSource = new BindingList<Subject>(chapters.ToList()); ;
            cboChapter.ValueMember = "Code";
            cboChapter.DisplayMember = "Name";
            cboChapter.SelectedItem = chapters.OrderByDescending(f => f.UpdateDate).FirstOrDefault();

            LoadGreatChild(allSubject);
        }

        private void LoadGreatChild(IList<Subject> allSubject)
        {
            if (allSubject == null)
            {
                allSubject = EFRepository<Subject>.Instance.LoadEntities();
            }

            var sections = allSubject.Where(s => s.ParentCode == (cboChapter.SelectedItem as Subject).Code);
            cboSection.DataSource = new BindingList<Subject>(sections.ToList()); ; ;
            cboSection.ValueMember = "Code";
            cboSection.DisplayMember = "Name";
            cboSection.SelectedItem = sections.OrderByDescending(f => f.UpdateDate).FirstOrDefault();

            LoadGreateGreatChild();
        }

        private void LoadGreateGreatChild()
        {
            Func<TCore, bool> where = f => f.SCode == (cboSection.SelectedItem as Subject).Code;
            if (chkCurSubject.Checked)
            {
                var subject = cboSubject.SelectedItem as Subject;
                where = f => f.SCode.StartsWith(subject.Code);
            }
            var topics = EFRepository<TCore>.Instance.LoadEntities(where);
            dataGridView1.AutoGenerateColumns = false;
            BindingList<TCore> datas = new BindingList<TCore>(topics);
            dataGridView1.DataSource = datas;
        }

        private void ProtectEye(Control.ControlCollection Controls)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {

                    var txt = item as TextBox;
                    txt.KeyDown += txt_KeyDown;
                    txt.BackColor = Color.FromArgb(199, 237, 204);
                }
                if (item.HasChildren)
                {
                    ProtectEye(item.Controls);
                }
            }
        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.Control | Keys.A) == e.KeyData)
            {
                var textbox = (sender as TextBox);
                textbox.HideSelection = false;
                textbox.SelectAll();
            }
        }
        string _text = string.Empty;
        const string mask = "█";

        bool ValidateInput()
        {
            if (txtC.Text.Contains(mask))
                return false;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
                return;
            _text = txtC.Text;
            EFRepository<TCore>.Instance.AddEntity(new TCore()
            {
                CreateDate = DateTime.Now,
                FStatus = true,
                SCode = cboSection.SelectedValue.ToString(),
                SContent = _text,
                Title = Util.GetTitle(_text)
            });

            LoadGreateGreatChild();
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Selected = true;
        }



        private void btnX1_Click(object sender, EventArgs e)
        {
            NewMethod(1);
        }

        private void NewMethod(int odd, int mod = 2)
        {
            txtC.Text = string.Empty;
            var array = _text.ToCharArray();
            int i = 0;
            foreach (var item in array)
            {
                i++;
                if (Fliter(item)
                    )
                {
                    txtC.Text += item;
                    continue;
                }
                if (i % mod == odd)
                {
                    txtC.Text += item;
                }
                else
                {
                    txtC.Text += mask;
                }

            }
        }

        private bool Fliter(char item)
        {
            var defaultFliter = " \t\r\n，。☆、：；的“'‘’”》《·…（）,.?？、【】[]-*()!！@#￥%&";
            if (defaultFliter.Contains(item)
                 )
            {
                return true;
            }
            return txtFliter.Text.Contains(item);
        }

        private void btnX2_Click(object sender, EventArgs e)
        {
            NewMethod(0);
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            txtC.Text = _text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shield(false);
        }

        private void Shield(bool exceptSpecial)
        {
            txtC.Text = string.Empty;
            var array = _text.ToCharArray();

            foreach (var item in array)
            {

                if (exceptSpecial && Fliter(item)
                  )
                {
                    txtC.Text += item;
                    continue;
                }
                txtC.Text += mask;
            }
        }

        private void btnX3_Click(object sender, EventArgs e)
        {
            NewMethod(0, (int)numericUpDown1.Value);
        }

        private void btnExceptSpecial_Click(object sender, EventArgs e)
        {
            Shield(true);
        }

        /// <summary>
        /// 替换掉考纲图片
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReplaceImg_Click(object sender, EventArgs e)
        {
            DlgReplaceImg dlg = new DlgReplaceImg();
            dlg.ShowDialog();
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subject = cboSubject.SelectedItem as Subject;
            UpdateSubjectLastUpdateTime(subject);
            LoadChild(null);
        }

        private void UpdateSubjectLastUpdateTime(Subject subject)
        {
            if (loding)
                return;
            subject.UpdateDate = DateTime.Now;
            EFRepository<Subject>.Instance.UpdateEntity(subject);
        }

        private void cboChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subject = cboChapter.SelectedItem as Subject;
            UpdateSubjectLastUpdateTime(subject);
            LoadGreatChild(null);
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subject = cboSection.SelectedItem as Subject;
            UpdateSubjectLastUpdateTime(subject);
            LoadGreateGreatChild();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void tsmiAddSubject_Click(object sender, EventArgs e)
        {
            DlgAddSubjet dlg = new DlgAddSubjet();
            dlg.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var list = dataGridView1.DataSource as BindingList<TCore>;
            if (e.RowIndex != -1)
            {
                var data = list[e.RowIndex];
                if (data.Title.StartsWith("[h]"))
                {
                    webBrowser1.Document.Body.InnerHtml = data.SContent;
                    _text = txtC.Text = webBrowser1.Document.Body.InnerText;
                }
                else
                {
                    _text = txtC.Text = data.SContent;
                }

            }
        }

        private void tsmiLook4Topic_Click(object sender, EventArgs e)
        {
            dlgTopic dlg = new dlgTopic();
            dlg.Show();
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            UserControls userControls = new UserControls();

            Thread thread = new Thread(userControls.DoWork) { IsBackground = true };
            thread.Start();
        }

        private void chkCurSubject_CheckedChanged(object sender, EventArgs e)
        {
            LoadGreateGreatChild();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {

                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                DataGridViewCell cell = dataGridView1.SelectedCells[0];
                var row = dataGridView1.Rows[cell.RowIndex];
                var tcore = row.DataBoundItem as TCore;
                var result = EFRepository<TCore>.Instance.DeleteEntity(tcore);
                if (result)
                {
                    dataGridView1.Rows.Remove(row);
                }
                else
                {
                    MessageBox.Show("操作：" + (result ? "成功" : "失败"));
                }
            }
            else
            {
                MessageBox.Show("未选中行");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
                return;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = dataGridView1.SelectedCells[0];
                var row = dataGridView1.Rows[cell.RowIndex];
                var tcore = row.DataBoundItem as TCore;
                tcore.SContent = txtC.Text;
                tcore.UpdateDate = DateTime.Now;
                var result = EFRepository<TCore>.Instance.UpdateEntity(tcore);
                MessageBox.Show("操作：" + (result ? "成功" : "失败"));
            }
            else
            {
                MessageBox.Show("未选中数据");
            }
        }

        private void tsmiGraphicCalc_Click(object sender, EventArgs e)
        {
            DlgGraphicCalc dlgGraphicCalc = new DlgGraphicCalc();
            dlgGraphicCalc.Show();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            HtmlDiff.HtmlDiff diffHelper = new HtmlDiff.HtmlDiff(txtMyText.Text, _text);
            //litOldText.Text = oldText;
            //litNewText.Text = newText;

            // Lets add a block expression to group blocks we care about (such as dates)
            diffHelper.AddBlockExpression(new Regex(@"[\d]{1,2}[\s]*(Jan|Feb)[\s]*[\d]{4}", RegexOptions.IgnoreCase));
            var compareText = diffHelper.Build();
            compareText = compareText.Replace("\r\n", "<br/>");
            webBrowser1.Document.Body.InnerHtml = compareText;

        }

        private void tsmiBuildPlan_Click(object sender, EventArgs e)
        {
            List<ReviewModel> list = new List<ReviewModel>() {
                //new  ReviewModel(){
                // ContinuousDays=3,
                //  Name="近现代史",
                //   PerDayChapter=3,
                //    TotalChapter=9,
                //},
                //           new  ReviewModel(){
                // ContinuousDays=1,
                //  Name="项目风险管理",
                //   PerDayChapter=2,
                //    TotalChapter=6,
                //},
                //           new  ReviewModel(){
                // ContinuousDays=3,
                //  Name="办公室管理",
                //   PerDayChapter=2,
                //    TotalChapter=9,
                //},
                 new  ReviewModel(){
                 ContinuousDays=1,
                  Name="007er",
                   PerDayChapter=1,
                    TotalChapter=52,
                },
                           new  ReviewModel(){
                 ContinuousDays=2,
                  Name="管理信息的收集与处理",
                   PerDayChapter=2,
                    TotalChapter=10,
                },
                           new  ReviewModel(){
                 ContinuousDays=2,
                  Name="能源工程技术概论（一）",
                   PerDayChapter=2,
                    TotalChapter=9,
                },
                                  new  ReviewModel(){
                 ContinuousDays=1,
                  Name="项目成本管理",
                   PerDayChapter=2,
                    TotalChapter=8,
                },
                           new  ReviewModel(){
                 ContinuousDays=1,
                  Name="现代项目质量管理",
                   PerDayChapter=2,
                    TotalChapter=8,
                },
                //                  new  ReviewModel(){
                // ContinuousDays=1,
                //  Name="法规",
                //   PerDayChapter=3,
                //    TotalChapter=6,
                //},
                   
                //           new  ReviewModel(){
                // ContinuousDays=1,
                //  Name="项目范围管理",
                //   PerDayChapter=2,
                //    TotalChapter=6,
                //},
            };
            StringBuilder sb = new StringBuilder();
            string reviewLine = "科目\t章节\t日期";
            sb.AppendLine(reviewLine);
            string reviewLineFormat = "{0}\t{1}\t{2}\r\n";

            DateTime dt = DateTime.Now.AddDays(1);
            while (dt < new DateTime(2019, 4, 1))
            {


                foreach (var item in list)
                {
                    for (int i = 0; i < item.ContinuousDays; i++)
                    {

                        for (int j = 0; j < item.PerDayChapter; j++)
                        {
                            if (item.LastChapter + 1 > item.TotalChapter)
                            {
                                item.LastChapter = 0;
                            }
                            item.LastChapter++;

                            sb.AppendFormat(reviewLineFormat, item.Name, "第" + (item.LastChapter) + "章", dt.ToString("yyyy-MM-dd"));

                        }
                        dt = dt.AddDays(1);
                    }
                }

            }
            var s = sb.ToString();
            LogHelper.Ins.Info(s);
        }

        private void tsmiDownAttachment_Click(object sender, EventArgs e)
        {

            dlgAttachment dlgGraphicCalc = new dlgAttachment();
            dlgGraphicCalc.Show();
        }

        private void tsmiBuildCatalog_Click(object sender, EventArgs e)
        {
            Dlg51ctoCatalog dlg51ctoCatalog = new Dlg51ctoCatalog();
            dlg51ctoCatalog.ShowDialog();
        }

        private void tsmi添加知识点_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveHtml_Click(object sender, EventArgs e)
        {

            if (ValidateInput() == false)
                return;
            var html = txtC.Text;
            html = Regex.Replace(html, @"<title>[\s\S]*?</form>", "");
            html = Regex.Replace(html, "&nbsp;", "");
            html = Regex.Replace(html, "<br.*?>", "</p><p>");
            html = Regex.Replace(html, "<div", "<p");
            html = Regex.Replace(html, "</div>", "</p>");
            html = Regex.Replace(html, @"\s+", " ");

            html = Regex.Replace(html, "<span", "<p");
            html = Regex.Replace(html, "</span>", "</p>");

            //_text = txtC.Text;

            webBrowser1.Document.Body.InnerHtml = html;

            var innerText = webBrowser1.Document.Body.InnerText;

            if (string.IsNullOrEmpty(innerText))
            {
                innerText = "找不到内容";
            }
            else
            {
                innerText = innerText.Trim();
            }
            _text = txtC.Text = innerText;

            var core = new TCore()
              {
                  CreateDate = DateTime.Now,
                  FStatus = true,
                  SCode = cboSection.SelectedValue.ToString(),
                  SContent = html,

                  Title = "[h]" + Util.GetTitle(innerText)
              };
            var result = EFRepository<TCore>.Instance.AddEntity(core);
            if (result)
            {
                LoadGreateGreatChild();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Selected = true;
            }
            else
            {
                statusLabel.Text = ".AddEntity(core)失败了";
            }
        }

        private void btnBuildHtml_Click(object sender, EventArgs e)
        {
            var sRows = dataGridView1.SelectedRows;
            if (sRows.Count == 0)
            {
                MessageBox.Show("请选择要生成的左侧列表项", "提示");
                return;
            }
            HtmlBuilder hb = new HtmlBuilder();
            foreach (DataGridViewRow item in sRows)
            {
                var tcore = item.DataBoundItem as TCore;
                hb.AddBodyItem(tcore.Title, tcore.SContent);
            }

            var html = hb.Build();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 获取解析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgAnalysis dlg = new DlgAnalysis();
            dlg.ShowDialog();

        }

        private void 重新整理pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var rootDir = @"F:\all";
            //var targetRootDir = @"F:\all\target";
            //var files = Directory.GetFiles(rootDir);
            //foreach (var item in files)
            //{
            //    var match = Regex.Match(item, @"(?<b>\d{4})");
            //    if (match.Success)
            //    {
            //        var year = match.Groups["b"].Value;
            //        var half = year + "年下半年";
            //        if (item.Contains("上半年"))
            //        {
            //            half = year + "年上半年";
            //        }
            //        var targetDir = Path.Combine(targetRootDir, half);
            //        if (Directory.Exists(targetDir) == false)
            //        {
            //            Directory.CreateDirectory(targetDir);
            //        }

            //        var targetPath = Path.Combine(targetDir, Path.GetFileName(item));
            //        File.Copy(item, targetPath);
            //    }
            //}

        }

        private void 生成错题解析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Body.InnerHtml = "";
            var fileName = GetOpenFilePath();
            var html = File.ReadAllText(fileName, Encoding.UTF8);
            var pattern = @"<span id=""tanalytic\d+-(?<tm>\d+)"">(?<b>[\s\S]*?)<title>[\s\S]*?</span>";
            MatchCollection mcT = Regex.Matches(html, pattern);
            foreach (Match item in mcT)
            {
                var match = item;
                var reMatch = Regex.Match(item.Value, pattern, RegexOptions.RightToLeft);
                if (reMatch.Success)
                {
                    match = reMatch;
                }
                GetTanalytic(match);
            }
        }

        private void GetTanalytic(Match match)
        {


            var html = match.Value;
            if (string.IsNullOrEmpty(match.Groups["b"].Value))
            {
                return;
            }
            html = Regex.Match(html,@"<span id="".*?"">(?<b>[\s\S]*?)<title>").Groups["b"].Value;
            
            html = Regex.Replace(html, "&nbsp;", "");
            html = Regex.Replace(html, "<br.*?>", "</p><p>");
            html = Regex.Replace(html, "<div", "<p");
            html = Regex.Replace(html, "</div>", "</p>");
            html = Regex.Replace(html, @"\s+", " ");
            html = Regex.Replace(html, "(\r\n)+", "\r\n");
             var removeTag = Regex.Replace(html, "<.*?>", "");
            var sTm = match.Groups["tm"].Value;
            var iTm = 0;
            if (int.TryParse(sTm, out iTm))
            {
                sTm = (iTm+1).ToString("d2");
            }
            webBrowser1.Document.Body.InnerHtml += string.Format("<h3>第{0}题、{1}</h3>{2}", sTm, Util.GetTitle(removeTag), html);




        }

        private static string GetOpenFilePath(string fliter = "所有文件|*.*")
        {
            var fileName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            var dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                fileName = ofd.FileName;
            }
            ofd.Dispose();
            return fileName;
        }


    }
}
