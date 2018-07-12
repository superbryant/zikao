using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SubjectDAL : EFRepository<Subject>
    {
       
        public int GetMax1SubjectCode()
        {
            int i = 0;
            var list = this.LoadEntities();
            if (list.Count == 0)
                return i;

            var lastMax = list.Where(f => f.Code.Length == 3).Max(f=>f.Code);
            i = int.Parse(lastMax) ;

            return i;
        }
    }
}
