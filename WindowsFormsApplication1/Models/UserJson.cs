using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    public class ResultMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string addType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string applyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string certNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string certType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int concernCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int concernedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int contentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string creator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string education { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string emergencyRel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string examProvince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string firstProjectIds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gradeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gradeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string graduateAcademy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hadithsUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string homePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string huluoUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int imUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string industry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isVip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lessonAttendTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string levelRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string materialProvince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> medalList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nicknameBbs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string officePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string operatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int postCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string postcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string profession { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qqCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qtCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string referer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string regLandingPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string regServicePage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string regTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string school { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sunlandsAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string syncBbs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trainingCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string urgentLinker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string urgentMobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string userGroupNickName { get; set; }
        /// <summary>
        /// 芝士学院-自考项目管理专业家族-学生
        /// </summary>
        public string userMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> userMarkList { get; set; }
        /// <summary>
        /// 吕敏
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string weixinId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string workYear { get; set; }
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
        public ResultMessage resultMessage { get; set; }
    }
}
