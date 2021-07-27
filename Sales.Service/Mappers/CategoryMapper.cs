using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.ViewModels.Internal;
using System;

namespace Sales.Service.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() {

            CreateMap<Category, CategoryDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<Category, CategoryViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryDto, Category>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryViewModel, Category>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryViewModel, CategoryDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<Category>, PagedViewModel<CategoryViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<CategoryDto>, PagedViewModel<CategoryViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
