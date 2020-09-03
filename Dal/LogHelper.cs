using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class LogEX
    {
        //[System.Data.Entity.Validation.DbEntityValidationException] = {"对一个或多个实体的验证失败。有关详细信息，请参阅“EntityValidationErrors”属性。"}
        public static void Error(this ILog log, DbEntityValidationException ex)
        {
            if (ex != null) {
                if (ex.EntityValidationErrors != null && ex.EntityValidationErrors.Count() > 0) {
                    foreach (var item in ex.EntityValidationErrors)
                    {
                        foreach (var err in item.ValidationErrors)
                        {
                            log.ErrorFormat("{0}:{1}", err.PropertyName, err.ErrorMessage);
                        }
                    }
                }
            }
        }

    }
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
