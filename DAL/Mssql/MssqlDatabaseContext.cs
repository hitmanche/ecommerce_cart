using CL;
using CL.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DAL.Mssql
{
    public class MssqlDatabaseContext:DbContext
    {
        public MssqlDatabaseContext():base(GetOptions())
        {
            //Database.Migrate();
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), Configuration.prmSqlConnection).Options;
        }

        public DbSet<product> product { get; set; }
        public DbSet<stock> stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<stock>().HasKey(x => new { x.id, x.product });
        }
    }
}
