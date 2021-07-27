using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Dto;
using Sales.Model.Entities;
using Sales.Service.ViewModels.Internal;
using System;

namespace Sales.Service.Mappers
{
    public class CategoryTaxMapper: Profile
    {
        public CategoryTaxMapper() {

            CreateMap<CategoryTax, CategoryTaxDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryTax, CategoryTaxViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryTaxDto, CategoryTaxViewModel>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryTaxDto, CategoryTax>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryTaxViewModel, CategoryTax>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<CategoryTaxViewModel, CategoryTaxDto>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<CategoryTax>, PagedViewModel<CategoryTaxViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<PagedList<CategoryTaxDto>, PagedViewModel<CategoryTaxViewModel>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();
        }
    }
}
