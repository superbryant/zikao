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
    public partial class DlgAddSubjet : Form
    {
        public DlgAddSubjet()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                SubjectDAL subjectDAL = new SubjectDAL();
                var max1Code = subjectDAL.GetMax1SubjectCode();
                var subjects = txtSubject.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string subject, chapter, section;
                int subjectCode = max1Code, chapterCode = 0, sectionCode = 0;

                foreach (var item in subjects)
                {
                    if  (Regex.IsMatch( item,"^\t.*?") == false)
                    {
                        subjectCode++;
                        subject = item;
                        var entity = new Subject()
                      {
                          Code = subjectCode.ToString("d3"),
                          Name = subject.Trim(),
                          ParentCode = string.Empty,
                          CreateDate = DateTime.Now,
                          Remark = string.Empty,
                          UpdateDate = DateTime.Now
                      };
                        subjectDAL.AddEntity(entity);
                    }
                    else if (Regex.IsMatch(item, "^\t{3}.*?")) { 
                    
                    }
                    else if (Regex.IsMatch(item, "^\t{2}.*?"))
                    {
                        sectionCode++;
                        section = item;
                        var entity = new Subject()
                             {
                                 Code = subjectCode.ToString("d3") + chapterCode.ToString("d3") + sectionCode.ToString("d3"),
                                 Name = section.Trim(),
                                 ParentCode = subjectCode.ToString("d3") + chapterCode.ToString("d3"),
                                 CreateDate = DateTime.Now,
                                 Remark = string.Empty,
                                 UpdateDate = DateTime.Now
                             };
                        subjectDAL.AddEntity(entity);
                    }
                    else if (Regex.IsMatch(item, "^\t.*?"))
                    {
                        chapterCode++;
                        chapter = item;
                        var entity = new Subject()
                            {
                                Code = subjectCode.ToString("d3") + chapterCode.ToString("d3"),
                                Name = chapter.Trim(),
                                ParentCode = subjectCode.ToString("d3"),
                                CreateDate = DateTime.Now,
                                Remark = string.Empty,
                                UpdateDate = DateTime.Now
                            };
                        subjectDAL.AddEntity(entity);
                    }
                }

                MessageBox.Show("导入成功！");
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
