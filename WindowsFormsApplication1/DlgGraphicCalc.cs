using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DlgGraphicCalc : Form
    {
        public DlgGraphicCalc()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var leftList = GetGraphiList(txtLeft.Text);
            var rightList = GetGraphiList(txtRight.Text);
            List<List<int>> output = new List<List<int>>();
            txtOuput.Text = string.Empty;
            for (var i = 0; i < leftList.Count; i++)
            {
                var outputLine = new List<int>();
                output.Add(outputLine);
                for (var j = 0; j < leftList[i].Count; j++)
                {
                    if (j > 0)
                    {
                        txtOuput.AppendText("\t");
                    }
                    outputLine.Add(leftList[i][j] || rightList[i][j] ? 1 : 0);
                    txtOuput.AppendText(leftList[i][j] || rightList[i][j] ? "1" : "0");

                }
                txtOuput.AppendText("\r\n");
            }

        }

        private List<List<bool>> GetGraphiList(string text)
        {
            var left = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<List<bool>> leftList = new List<List<bool>>();
            foreach (var leftLine in left)
            {
                var lefts = leftLine.Split('\t');
                var leftModel = new List<bool>();
                leftList.Add(leftModel);
                foreach (var aItem in lefts)
                {
                    leftModel.Add(aItem.Trim() == "1");
                }
            }
            return leftList;
        }

      

        private void btnSub_Click(object sender, EventArgs e)
        {
            var leftList = GetGraphiList(txtLeft.Text);
            var rightList = GetGraphiList(txtRight.Text);
            //for (int l = 0; l < leftList.Count; l++)
            //{
            var outputList = new List<List<bool>>();
            for (int r = 0; r < rightList.Count; r++)
            {
             
                for (int i = 0; i < leftList.Count; i++)
                {
                    bool? flag = null;
                    for (int j = 0; j < rightList.Count; j++)
                    {
                        if (flag == null)
                        {
                            flag = leftList[i][j] && rightList[j][r];
                        }
                        else
                        {
                            flag = flag.Value || (leftList[i][j] && rightList[j][r]);
                        }
                        //第一个的时候是对的
                        //leftList[i][j]*rightList[i][j]
                        //第二个的时候是对的
                        //leftList[i][j]*rightList[j][i]
                        //第三个的时候是对的
                        //leftList[i][j]*rightList[j][i]
                    }
                    if (outputList.Count < i + 1)
                    {
                        outputList.Add(new List<bool>());
                    }
                    outputList[i].Add(flag.Value);
                }
              

                //目标: l[i]*r[j]+l[i+1]*r[j+1]+l[i+2]*r[j+2]+...

            }
            txtOuput.Text = "";
            foreach (var item in outputList)
            {
                foreach (var boolItem in item)
                {
                    txtOuput.AppendText(boolItem ? "1" : "0");
                    txtOuput.AppendText( "\t");
                }
                txtOuput.AppendText("\r\n");
            }
        }

    }
}
