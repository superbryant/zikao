using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class P_ChinesePracticeDAL : EFRepository<P_ChinesePractice>
    {

        public P_ChinesePractice GetChinesePractice(DateTime dt)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                var list = entities.P_ChinesePractice.Where(f => f.crateDate == dt && f.sucess < 3).ToList();
                if (list == null || list.Count == 0)
                {
                    return null;
                }
                Random r = new Random();
                var i = r.Next(0, list.Count);
                return list[i];
            }
        }

        public bool UpdateSucess(int id, bool isSucess)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                string sql = string.Format(@"UPDATE [dbo].[P_ChinesePractice]
   SET  [sucess] =sucess {0} 1
      ,[UpdateDate] =getdate()
 WHERE  id={1}", isSucess ? "+" : "-", id);
                return entities.Database.ExecuteSqlCommand(sql) > 0;

            }
        }
    }
}
