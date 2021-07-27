using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;

namespace Sales.Service.Services.Interfaces
{
    public interface IItemPriceService : IEntityServiceBase<ItemPrice, ItemPriceDto, ItemPriceViewModel>
    {

    }
}