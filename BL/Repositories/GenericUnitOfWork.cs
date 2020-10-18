using DAL.Mssql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Repositories
{
	public class GenericUnitOfWork : IDisposable
    {
		private MssqlDatabaseContext _context;


		public GenericUnitOfWork()
		{
			this._context = new MssqlDatabaseContext();
		}

		public async Task<int> SaveChanges()
		{
			var result = await _context.SaveChangesAsync();
			return result;
		}

		public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
		public IRepository<TEntity> Repository<TEntity>() where TEntity : class
		{
			if (repositories.Keys.Contains(typeof(TEntity)) == true)
			{
				return repositories[typeof(TEntity)] as IRepository<TEntity>;
			}

			IRepository<TEntity> repository = new GenericRepository<TEntity>();
			repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		private bool disposed = false;
		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
