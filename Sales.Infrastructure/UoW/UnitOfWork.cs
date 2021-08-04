using Microsoft.EntityFrameworkCore.Storage;
using Sales.Infrastructure.Contexts;
using Sales.Model.UoW.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sales.Infrastructure.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: Recebe o Context por injeção de dependência
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public IExecutionStrategy CreateExecutionStrategy() => _context.Database.CreateExecutionStrategy();

        /// <summary>
        /// Permite a implementação de Transaction para cenários específicos.
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Utilizado quando há erros na gravação de dados em cenários com Transaction
        /// </summary>
        /// <param name="dbContextTransaction"></param>
        public void RollBackTransaction(IDbContextTransaction dbContextTransaction)
        {
            dbContextTransaction.Rollback();
        }

        /// <summary>
        /// Utilizado para consolidar as alterações dentro de uma transaction
        /// </summary>
        /// <param name="dbContextTransaction"></param>
        /// <returns></returns>
        public void CommitTransaction(IDbContextTransaction dbContextTransaction)
        {
            dbContextTransaction.Commit() ;
        }

        /// <summary>
        /// Utilizado para o commit de todas as ações aninhadas, quando não existe o cenário de Transaction.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Aciona internamente o método Commit. Criado apenas para facilitar a leitura do código em cenários onde existem Transactions.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return await CommitAsync();
        }

        /// <summary>
        /// Salva as alterações no contexto.
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Salva as alterações no contexto.
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Descarte do objeto da memória. 
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
