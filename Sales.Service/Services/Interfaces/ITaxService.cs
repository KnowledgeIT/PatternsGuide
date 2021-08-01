using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Threading.Tasks;

namespace Sales.Service.Services.Interfaces
{
    public interface ITaxService : IEntityServiceBase<Tax, TaxDto, TaxViewModel>
    {
        Task<Order> Calculate(Order order);
        ValueTask<decimal> GetTotalTaxesByItem(int itemId, bool sumImported = false);
    }
}