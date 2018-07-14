using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LogHelper
    {
        static ILog _log = null;


        public static ILog Ins
        {
            get
            {
                if (_log == null)
                {
                    _log = log4net.LogManager.GetLogger("FileAppender");
                }
                return _log;
            }
        }

    }
}
