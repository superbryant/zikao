using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp.Model
{
    public class FallaciesModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 歪曲观点
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string slug { get; set; }
            /// <summary>
            /// 又被称“稻草人”谬误，指歪曲他人的论据以使其变得更易受抨击。
            /// </summary>
            public string head { get; set; }
            /// <summary>
            /// 又被称“稻草人”谬误，指歪曲他人的论据以使其变得更易受抨击。
            /// </summary>
            public string first { get; set; }
            /// <summary>
            /// 通过夸大、歪曲，又甚至完全假造对手的论据，让自身的立场呈现更多的合理性。但坦诚理性的辩论会被这种实质是欺诈的论述破坏。

            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 小明说：国家应当向医疗和教育领域投入更多的资金。小亮回答：太可怕了，你居然这么仇恨国家，想要通过减少国防开支，让我们的军队手无寸铁而无法保卫国家。
            /// </summary>
            public string example { get; set; }
            /// <summary>
            /// 你的逻辑谬误是 歪曲观点
            /// </summary>
            public string pageTitle { get; set; }
            /// <summary>
            /// 例子: 小明说：国家应当向医疗和教育领域投入更多的资金。小亮回答：太可怕了，你居然这么仇恨国家，想要通过减少国防开支，让我们的军队手无寸铁而无法保卫国家。
            /// </summary>
            public string exampleText { get; set; }
            /// <summary>
            /// 
            /// </summary>
            //public Meta meta { get; set; }
         



    
    }
}
