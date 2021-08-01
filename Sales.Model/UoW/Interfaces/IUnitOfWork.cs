using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sales.Model.UoW.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task<IDbContextTransaction> BeginTransaction();
        void RollBackTransaction(IDbContextTransaction dbContextTransaction);
        void CommitTransaction(IDbContextTransaction dbContextTransaction);
        bool Commit();
        Task<bool> CommitAsync();
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
