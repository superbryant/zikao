using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(Application.StartupPath, @"log4net.config")));
            //var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var list2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var list3 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var list4 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var result = new List<List<int>>();

            //for (int i = 0; i < list.Count; i++)
            //{


            //    for (int j = 0; j < list2.Count; j++)
            //    {
            //        for (int k = 0; k < list3.Count; k++)
            //        {
            //            for (int l = 0; l < list4.Count; l++)
            //            {
            //                List<int> item = new List<int>();
            //                item.Add(list[i]);
            //                item.Add(list2[j]);
            //                item.Add(list3[k]);
            //                item.Add(list4[l]);
            //                result.Add(item);
            //            }
            //        }
            //    }
            //}

            //var four = result.Where(f => f.Where(t => t == 4).Count() == 2);
            //foreach (var item in four)
            //{
            //    Console.WriteLine(string.Join(",",item));
            //}
            //var rc = result.Count;
            Application.Run(new FrmMain());
        }
    }
}
