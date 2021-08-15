using Microsoft.Extensions.Configuration;
using Sales.CrossCutting.Extensions;
using Sales.CrossCutting.Properties;
using Sales.Model.Repositories.Base.Interfaces.Sql;

namespace Orcamento.Infrastructure.SQL.Repositories.Base
{
    public abstract class SqlRepositoryBase : ISqlRepositoryBase
    {
        protected readonly ConfigurationBuilder _config;
        protected readonly string _connectionString;

        public SqlRepositoryBase()
        {
            _config = new ConfigurationBuilder();
            _connectionString = _config.GetConnectionStringFromEnvironment(SharedConnection.ConnectionString);
        }
    }
}
