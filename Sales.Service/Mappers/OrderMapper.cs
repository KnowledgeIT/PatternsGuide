using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.ViewModels.Internal;

namespace Sales.Service.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper() {

            CreateMap<Order, OrderDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<OrderDto, OrderViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<OrderDto, Order>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<OrderViewModel, Order>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<OrderViewModel, OrderDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<OrderReceiptDto, OrderReceiptViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<Order>, PagedViewModel<OrderViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<OrderDto>, PagedViewModel<OrderViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
