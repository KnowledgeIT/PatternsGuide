using Sales.Application.AppServices;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories;
using Sales.Infrastructure.Repositories.Interfaces;
using Sales.Infrastructure.UoW;
using Sales.Infrastructure.UoW.Interfaces;
using Sales.Service.Services;
using Sales.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Sales.CrossCutting.IoC.DependencyInjection
{
    public static class RegisterServices
    {
        public static void RegisterHttpSettings(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IItemCategoryAppService, ItemCategoryAppService>();
            services.AddScoped<IItemPriceAppService, ItemPriceAppService>();
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IOrderItemAppService, OrderItemAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<ITaxAppService, TaxAppService>();
        }

        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemCategoryService, ItemCategoryService>();
            services.AddScoped<IItemPriceService, ItemPriceService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITaxService, TaxService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddScoped<IItemPriceRepository, ItemPriceRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
        }
    }
}
