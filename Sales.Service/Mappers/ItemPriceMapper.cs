using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.ViewModels.Internal;
using System;

namespace Sales.Service.Mappers
{
    public class ItemPriceMapper : Profile
    {
        public ItemPriceMapper() {

            CreateMap<ItemPrice, ItemPriceDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemPrice, ItemPriceViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemPriceDto, ItemPriceViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemPriceDto, ItemPrice>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemPriceViewModel, ItemPrice>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemPriceViewModel, ItemPriceDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<ItemPrice>, PagedViewModel<ItemPriceViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<ItemPriceDto>, PagedViewModel<ItemPriceViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
