using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.ViewModels.Internal;
using System;

namespace Sales.Service.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper() {

            CreateMap<Item, ItemDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<Item, ItemViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemDto, ItemViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemDto, Item>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemViewModel, Item>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<ItemViewModel, ItemDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<Item>, PagedViewModel<ItemViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<ItemDto>, PagedViewModel<ItemViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
