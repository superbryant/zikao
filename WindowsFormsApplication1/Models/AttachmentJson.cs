using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class AttachmentJson
    {
        public class AttachmentListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string batchId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int businessId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int businessType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime createTime { get; set; }
            /// <summary>
            /// 杨豆
            /// </summary>
            public string creator { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int downloadTimes { get; set; }
            /// <summary>
            /// 管理信息的收集与处理 精讲一.pptx
            /// </summary>
            public string fileName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string fileSize { get; set; }
            /// <summary>
            /// /course_template/attachment/6f9b0bd46d744e38c84da6a775b40ea8/管理信息的收集与处理 精讲一.pptx
            /// </summary>
            public string fileUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string record { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<AttachmentListItem> attachmentList { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool success { get; set; }
        }
    }
}
