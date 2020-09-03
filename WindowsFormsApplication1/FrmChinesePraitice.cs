using Dal;
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
    public partial class FrmChinesePraitice : Form
    {
        public FrmChinesePraitice()
        {
            InitializeComponent();
            this.Load += FrmChinesePraitice_Load;
        }

        void FrmChinesePraitice_Load(object sender, EventArgs e)
        {
            P_ChinesePracticeDAL dal = new P_ChinesePracticeDAL();
            var model = dal.GetChinesePractice(dtpDate.Value.Date);
            if (model == null) {
                MessageBox.Show("恭喜你完成了今天的任务，明天再来吧 OVER！！！");
                return;
            }
            txtWord.Text = model.word;
            Random r = new Random();
            List<string> pys = new List<string>();
            pys.Add(model.pinyin);

            if (model.pinyin.EndsWith("ɡ"))
            {
                pys.Add(model.pinyin.TrimEnd('ɡ'));
            }
            else
            {
                pys.Add(model.pinyin + ('ɡ'));
            }
            var i = r.Next(0, 2);
            if (i == 0)
            {
                rdoA.Text = pys[0];
                rdoB.Text = pys[1];
            }
            else
            {
                rdoA.Text = pys[1];
                rdoB.Text = pys[0];
            }
            txtWord.Tag = model;
           rdoA.Checked= rdoB.Checked = false;
        }
        int answerCount = 0;
        private void rdoB_CheckedChanged(object sender, EventArgs e)
        {
            answerCount++;
            if (answerCount == 1) {
                return;
            }

            P_ChinesePracticeDAL dal = new P_ChinesePracticeDAL();


            var model = txtWord.Tag as P_ChinesePractice;
            var rdo = sender as RadioButton;
           var sucess= rdo.Text == model.pinyin;
           if (sucess) {
               lblStatus.Text = string.Format("{0}（{1}）,答对了",model.word, model.pinyin);
               lblStatus.ForeColor = Color.Green;
           }
           else
           {
               lblStatus.Text = string.Format("{0}（{1}）,答错了", model.word, model.pinyin);
               lblStatus.ForeColor = Color.Red;
           }
           dal.UpdateSucess(model.id, sucess);

            FrmChinesePraitice_Load(sender,e);
        }
    }
}
