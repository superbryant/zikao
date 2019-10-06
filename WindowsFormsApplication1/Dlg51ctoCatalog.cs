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
    public partial class Dlg51ctoCatalog : Form
    {
        public Dlg51ctoCatalog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // <li class="chaper">第五章 精典类计算</li>
            //<span class="num fl">5-1</span><p class="fl">经典计算01</p>
            var matchCatalog = Regex.Matches(txtUl.Text,@"<li class=""chaper"">(?<c>.*?)</li>");
            foreach (Match  catalog in matchCatalog)
            {
                txtResult.AppendText(catalog.Groups["c"].Value);
                txtResult.AppendText("\r\n");
            }

            var matchCatalogSon = Regex.Matches(txtUl.Text, @"<span class=""num fl"">(?<nf>.*?)</span><p class=""fl"">(?<fl>.*?)</p>");
            foreach (Match catalog in matchCatalogSon)
            {
                txtResult.AppendText(catalog.Groups["nf"].Value + "," + catalog.Groups["fl"].Value);
                txtResult.AppendText("\r\n");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
