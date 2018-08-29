using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class QuestionDAL : EFRepository<Question>
    {

        public int GetMaxQuestionId()
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                var max = entities.Question.Max(f => f.QuizzesGroupId);
                if (max == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(max);
                }
            }
        }

        public List<Question> GetQuestion(int take)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                var list = entities.Question.Where(f => f.Title != "").OrderByDescending(f => f.QuizzesGroupId).Take(take);
                return list.ToList();
            }
        }

        public List<Question> GetQuestion(string search, int take)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                var list = entities.Question.Where(f => f.Title.Contains(search)).OrderByDescending(f => f.QuizzesGroupId).Take(take);
                return list.ToList();
            }
        }

        public bool UpdateComplected(string id)
        {
            using (ZiKaoEntities entities = new ZiKaoEntities())
            {
                string sql = @"UPDATE [dbo].[Question]
   SET  [Comp] = 1
      ,[UpdateDate] =getdate()
 WHERE  QuizzesGroupId=" + id;
              return   entities.Database.ExecuteSqlCommand(sql)>0;

            }
        }
    }
}
