using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class AttachmentJson
    {
        public class ResultMessageItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int docId { get; set; }
            /// <summary>
            /// 工程经济学串讲讲义201912.pdf
            /// </summary>
            public string docName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string docSize { get; set; }
            /// <summary>
            /// https://sfs-public.shangdejigou.cn/teach-resource/tw/user_center/faceLive/5110063/工程经济学串讲讲义201912.pdf
            /// </summary>
            public string docDownloadUrl { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int rs { get; set; }
            /// <summary>
            /// 
            /// </summary>item
            public string errorCode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string errorMessage { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<ResultMessageItem> resultMessage { get; set; }
        }
    }
}
