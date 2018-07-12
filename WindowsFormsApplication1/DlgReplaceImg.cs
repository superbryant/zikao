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
    public partial class DlgReplaceImg : Form
    {
        public DlgReplaceImg()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                var text = string.Empty;
                using (var fs = File.OpenText(txtHtmlPath.Text))
                {
                    text = fs.ReadToEnd();
                    var matches = Regex.Matches(text, "<img.*?>");
                    var imgFils = Directory.GetFiles(txtImgDir.Text).Select(f => Path.GetFileName(f));
                    foreach (Match item in matches)
                    {
                        if (imgFils.Any(f => item.Value.Contains(f)) == false)
                        {
                            text = text.Replace(item.Value, "");
                        }
                    }
                }
                using (var fs = File.OpenWrite(txtHtmlPath.Text))
                {
                    var buff = Encoding.UTF8.GetBytes(text);
                    fs.Write(buff, 0, buff.Length);
                }
                MessageBox.Show("替换成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
