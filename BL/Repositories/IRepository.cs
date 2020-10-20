using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> First(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Update(TEntity entity, params object[] keyValues);
    }
}
