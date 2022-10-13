using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp.Util
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
