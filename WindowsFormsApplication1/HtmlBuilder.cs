using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class HtmlBuilder
    {
        private string _head;
        private string _foot;
        private string _body;
        private int _i;
        public HtmlBuilder()
        {
            _head = @" 
<html>
<head>
  <meta charset=""UTF-8"">
  <style>
  body{  font-family: ""宋体"" ;font-size:14px;    background-color: #dff0d8; }
  h3{   font-size:16px ;
 font-weight: bold;

  }
  h2{   font-size:20px ;
 font-weight: bold;
text-align:center;
  }
  p{   
text-indent: 2em;
margin: 0px;
text-align:justify;
  }
  </style>
  </head>
<body>";

            _foot = @"</body>
</html>";
            _body = "";

            _i = 1;
        }

        public void AddBodyItem(string title, string content)
        {
            _body += "<h3>必胜" + _i + "、" + SubTitle(title) + "</h3>";
            _body += content;

            _i++;
        }

        private string SubTitle(string p)
        {
            string result = p;

            if (result != null)
            {
                if (result.StartsWith("[h]") && result.Length > 3)
                {
                    result = result.Substring(3);
                }
                if (result.Length > 30)
                {
                    result = result.Substring(0, 30);
                }
            }
            return result;
        }

        public string Build()
        {
            string result="";
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "html|*.html" })
            {
                var dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    var fileName = sfd.FileName;
                    var title = "<h2>" + Path.GetFileNameWithoutExtension(fileName) + "</h2>";
                      result = _head + title + _body + _foot;
                    File.WriteAllText(fileName, result, Encoding.UTF8);
                    var isOp = MessageBox.Show("是否打开?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (isOp == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(fileName);
                    }
                }
            };
            return result;
        }

    }
}
