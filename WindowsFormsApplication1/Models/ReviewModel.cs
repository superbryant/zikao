using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    /// <summary>
    /// 复习科目
    /// </summary>
    public class ReviewModel
    {
        /// <summary>
        /// 科目名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 章节总数
        /// </summary>
        public int TotalChapter { get; set; }
        /// <summary>
        /// 每天学记章节
        /// </summary>
        public int PerDayChapter { get; set; }

        /// <summary>
        /// 上次到第几章节了
        /// </summary>
        public int LastChapter { get; set; }
        /// <summary>
        /// 连续学习天数
        /// </summary>
        public int ContinuousDays { get; set; }
    }
}
