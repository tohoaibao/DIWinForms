using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DIWinForms.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);

        void Save();

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    }
}
