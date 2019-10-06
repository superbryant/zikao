using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace Dal
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool UpdateEntity(IEnumerable<TEntity> entities);
        bool DeleteEntity(int ID);
        bool DeleteEntity(TEntity entity);
        bool DeleteEntity(Expression<Func<TEntity, bool>> predicate);
        bool DeleteEntity(IEnumerable<TEntity> entities);
        IList<TEntity> LoadEntities(Func<TEntity, bool> whereLambda);
        IList<TEntity> LoadEntities(int pageIndex = 1, int pageSize = 30, Func<TEntity, bool> whereLambda = null);
        TEntity FindByID(int ID);
    }

    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        #region 单利模式

        public static EFRepository<TEntity> Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EFRepository<TEntity>();
                }
                return _Instance;
            }

        }
        static EFRepository<TEntity> _Instance;

        public EFRepository()
        {
            _Context = new ZiKaoEntities();
        }
        #endregion

        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        public DbContext Context
        {
            get
            {
                return _Context;
            }
            private set
            {
                _Context = value;
            }
        }
        public bool AddEntity(TEntity entity)
        {

            try
            {
                EntityState state = Context.Entry(entity).State;
                if (state == EntityState.Detached)
                {
                    Context.Entry(entity).State = EntityState.Added;
                }
                Context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                LogHelper.Ins.DbError(ex);
            }
            catch (Exception ex)
            {
                LogHelper.Ins.Error(ex);
            }
            return false;
        }
        public bool UpdateEntity(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
        public bool UpdateEntity(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    UpdateEntity(entity);
                }
                return true;
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public bool DeleteEntity(int ID)
        {
            TEntity entity = FindByID(ID);
            return DeleteEntity(entity);
        }
        public bool DeleteEntity(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }
        public bool DeleteEntity(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = Set().Where(predicate).ToList();
            return Context.SaveChanges() > 0;
        }
        public bool DeleteEntity(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    DeleteEntity(entity);
                }
                return true;
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public IList<TEntity> LoadEntities(Func<TEntity, bool> whereLambda)
        {
            if (whereLambda != null)
                return Context.Set<TEntity>().Where<TEntity>(whereLambda).AsQueryable().ToList();
            else
                return Context.Set<TEntity>().AsQueryable().ToList();
        }

        public IList<TEntity> LoadEntities()
        {
            return Set().ToList();
        }
        public IList<TEntity> LoadEntities(int pageIndex = 1, int pageSize = 30, Func<TEntity, bool> whereLambda = null)
        {
            int skinCount = (pageIndex - 1) * pageSize;
            if (whereLambda != null)
                return Set()
                    .Where<TEntity>(whereLambda)
                    .Skip(skinCount)
                    .Take(pageSize)
                    .ToList();
            else
                return Set()
                .Skip(skinCount)
                .Take(pageSize)
                .ToList();
        }
        public DbSet<TEntity> Set()
        {
            return Context.Set<TEntity>();
        }
        public TEntity FindByID(int ID)
        {
            return Set().Find(ID);
        }
        private TEntity Create()
        {
            return Context.Set<TEntity>().Create();
        }

        private DbContext _Context;
    }
}
