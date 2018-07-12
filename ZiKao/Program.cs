using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiKao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Review();
            var date = new DateTime(1921, 7, 23);//            1921年7月23
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                sb.AppendLine(date.ToShortDateString());
                date = date.AddYears(5);
                if (date > DateTime.Now)
                {
                    break;
                }
            }
            var s = sb.ToString();
            Console.WriteLine(s);


        }

        private static void Review()
        {

            string kemu = @"节能技术（一）	9
国统	11
马原	7
信息	10
人力资源管理（一）	10
环境（一）	11
工程（一）	9";
            string[] kemus = kemu.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            List<KeMu> keMus = new List<KeMu>();
            for (int i = 0; i < kemus.Length; i++)
            {

                var k = kemus[i].Split('\t');


                for (int j = 1; j <= int.Parse(k[1]); j++)
                {
                    KeMu model = new KeMu() { Order = i };
                    model.Name = k[0];
                    model.Chapter = int.Parse(k[1]);
                    model.ChapterNum = j;
                    keMus.Add(model);
                }
            }


            var orderKemus = keMus.OrderBy(f => f.ChapterNum).ThenBy(f => f.Order);
            StringBuilder sb = new StringBuilder();
            int q = 0;
            var day = 0;
            sb.AppendLine("日期\t第N天	科目	预计完成	实际完成");
            var flag = true;
            while (flag)
            {

                foreach (var item in orderKemus)
                {
                    if (q % 2 == 0)
                    {
                        day++;
                        if (day > 72)
                        {
                            flag = false;
                            break;
                        }
                    }
                    sb.AppendLine(string.Format("{4:yyyy-MM-dd}\t第{3}天\t{0}(共{2}章)\t第{1}章\t", item.Name, item.ChapterNum, item.Chapter, day, DateTime.Now.AddDays(day - 1)));
                    q++;
                }
            }

            var result = sb.ToString();
            Console.WriteLine(result);
            Console.Read();
        }
    }

    class KeMu
    {
        public int Order { get; set; }
        public int ChapterNum { get; set; }
        public int Chapter { get; set; }
        public string Name { get; set; }
    }
}
