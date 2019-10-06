using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DlgAnalysis : Form
    {
        public DlgAnalysis()
        {
            InitializeComponent();
            this.Load += DlgAnalysis_Load;
        }

        void DlgAnalysis_Load(object sender, EventArgs e)
        {
            InitialWebBrowser();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            var matches = Regex.Matches(txtInput.Text, @"<div class=""fl"">(?<b>[\s\S]*?)</div>");
            HtmlBuilder hb = new HtmlBuilder();
            foreach (Match item in matches)
            {
                var match = item.Groups["b"].Value;
                txtOuput.AppendText(match);
                txtOuput.AppendText("\r\n");
                var title = GetTitle(match);
                hb.AddBodyItem(title, match);
            }

            var html = hb.Build();
            webBrowser1.Document.Body.InnerHtml = html;
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

        private string GetTitle(string html)
        {
            var matches = Regex.Matches(html, @">(?<b>.*?)<");
            string title = string.Empty;
            var content = "";
            foreach (Match match in matches)
            {
                content += match.Groups["b"].Value;
            }
            title = Util.GetTitle(content);

            return title;
        }
    }
}
