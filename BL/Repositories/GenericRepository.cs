using DAL.Mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MssqlDatabaseContext _context;
        public GenericRepository(MssqlDatabaseContext context)
        {
            _context = context;
        }
        public async Task<TEntity> First(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity t, params object[] keyValues)
        {
            if (t == null)
                return null;
            TEntity exist = await _context.Set<TEntity>().FindAsync(keyValues);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }
    }
}
