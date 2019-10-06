using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{

    public static class LogEX
    {
        public static void DbError(this ILog log, DbEntityValidationException ex)
        {
            if (ex != null)
            {
                if (ex.EntityValidationErrors != null && ex.EntityValidationErrors.Count() > 0)
                {
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

}
