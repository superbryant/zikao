using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class LessionJson
    {
        public class User
        {
            /// <summary>
            /// 
            /// </summary>
            public int userId { get; set; }
            /// <summary>
            /// 曾宪
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userImg { get; set; }
        }

        public class ResultMessage
        {
            /// <summary>
            /// 
            /// </summary>
            public string liveToken { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string imToken { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string liveRoomId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int? teachUnitId { get; set; }
            /// <summary>
            /// 【工程经济学】项目本<精讲7>
            /// </summary>
            public string teachUnitName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long? teachUnitStartTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long? teachUnitEndTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string liveProvider { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int? teachUnitStatus { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string liveData { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int? code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public User user { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int rs { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string errorCode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string errorMessage { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ResultMessage resultMessage { get; set; }
        }
    }
}
