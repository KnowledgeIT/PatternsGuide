using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Contexts.Base
{
    public partial class ContextBase : DbContext
    {
        #region Constructor
    
        public ContextBase() { }
        public ContextBase(DbContextOptions<Context> options): base(options) { }

        #endregion

        #region OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LEGACY\LEGACY;Initial Catalog=SALES;Integrated Security=True;MultipleActiveResultSets=True;");

            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Src\KiT\PatternsGuide\Sales.Infrastructure\Sql\Sales.mdf;Integrated Security=True;MultipleActiveResultSets=True");

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        #endregion

        #region Custom


        #endregion
    }
}
    