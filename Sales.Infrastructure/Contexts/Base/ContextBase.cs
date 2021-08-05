using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sales.CrossCutting.Extensions;
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
            //optionsBuilder.UseSqlServer(@"Data Source=<Your Local Server>;AttachDbFilename=<Your Sales.mdf Path>;Integrated Security=True;MultipleActiveResultSets=True");
            //
            // Or, create the database and Environment Variable and use it like below:
            //
            var config = new ConfigurationBuilder();
            optionsBuilder.UseSqlServer(config.GetConnectionStringFromEnvironment("salesConnection"));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        #endregion

        #region Custom


        #endregion
    }
}
    