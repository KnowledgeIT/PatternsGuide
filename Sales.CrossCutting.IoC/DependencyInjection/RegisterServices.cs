using Microsoft.Extensions.DependencyInjection;
using Sales.Application.AppServices;
using Sales.Application.AppServices.Interfaces;
using Sales.Infrastructure.Contexts;
using Sales.Infrastructure.Repositories;
using Sales.Infrastructure.UoW;
using Sales.Model.Repositories.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services;
using Sales.Service.Services.Interfaces;

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
            services.AddScoped<IItemPriceAppService, ItemPriceAppService>();
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<ITaxAppService, TaxAppService>();
        }

        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemPriceService, ItemPriceService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITaxService, TaxService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemPriceRepository, ItemPriceRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
        }
    }
}
