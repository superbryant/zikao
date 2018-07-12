using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the next line to enable log4net internal debugging
            // log4net.Util.LogLog.InternalDebugging = true;
            Console.WriteLine("监测网络");
            // This will instruct log4net to look for a configuration file
            // called config.log4net in the root directory of the device
            log4net.Config.XmlConfigurator.Configure(new FileInfo(@"log4net.config"));

           var log= log4net.LogManager.GetLogger("FileAppender");
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            while (true)
            {
                try
                {
                    System.Net.NetworkInformation.PingReply pr =
                       p.Send(new System.Net.IPAddress(new byte[] { 123, 125, 114, 144 }), 3000);
                    log.Info(pr.Status);
                }
                catch (Exception ex)
                {
                    log.Error("异常：",ex);
                }
                Thread.Sleep(3000);
            }
            
            // This will shutdown the log4net system
            log4net.LogManager.Shutdown();
        }
    }
}
