using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TeachUnitDAL : EFRepository<TeachUnit>
    {

        public int GetMaxTeachUnitId()
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                var max = entities.TeachUnit.OrderByDescending(f => f.TeachId).Take(1).FirstOrDefault();
                if (max == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(max.TeachId);
                }
            }
        }

        //public List<TeachUnit> GetTeachUnit(int take)
        //{
        //    using (ZiKaoEntities entities = new ZiKaoEntities())
        //    {
        //        var list = entities.TeachUnit.Where(f => f.fileName != "").OrderByDescending(f => f.AutoId).Take(take);
        //        return list.ToList();
        //    }
        //}

        //public List<TeachUnit> GetTeachUnit(string search, int take)
        //{
        //    using (ZiKaoEntities entities = new ZiKaoEntities())
        //    {
        //        var query = entities.TeachUnit.Where(f => true);
        //       var seaches= search.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
        //       foreach (var item in seaches)
        //        {
        //            query = query.Where(f => f.fileName.Contains(item));
        //        }
        //        var list =query.OrderByDescending(f => f.AutoId).Take(take);
        //        return list.ToList();
        //    }
        //}

        public bool UpdateComplected(string id)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                string sql = @"UPDATE [dbo].[TeachUnit]
   SET  [Comp] = 1
      ,[UpdateDate] =getdate()
 WHERE  QuizzesGroupId=" + id;
                return entities.Database.ExecuteSqlCommand(sql) > 0;

            }
        }
    }
}
