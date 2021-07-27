using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using Sales.CrossCutting.Extensions;
using Sales.CrossCutting.IoC.DependencyInjection;
using Sales.Filters;
using Sales.Service.Mappers;

namespace Sales
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("SalesPolicy", builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
            }));

            services.AddAutoMapper(x => x.AddProfile(new CategoryMapper()));
            services.AddAutoMapper(x => x.AddProfile(new CategoryTaxMapper()));
            services.AddAutoMapper(x => x.AddProfile(new ItemCategoryMapper()));
            services.AddAutoMapper(x => x.AddProfile(new ItemMapper()));
            services.AddAutoMapper(x => x.AddProfile(new ItemPriceMapper()));
            services.AddAutoMapper(x => x.AddProfile(new OrderItemMapper()));
            services.AddAutoMapper(x => x.AddProfile(new OrderMapper()));
            services.AddAutoMapper(x => x.AddProfile(new TaxMapper()));

            services.AddControllers();

            services.RegisterHttpSettings();
            services.RegisterRepositories();
            services.RegisterDomainServices();
            services.RegisterAppServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sales",
                    Version = "v1",
                    Description = "Sales SOLID Sample"
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
            });

            var configLogger = new ConfigurationBuilder().Build();
            string loggerConnection = new ConfigurationBuilder().GetConnectionStringFromEnvironment("mongoConnection");
            GlobalDiagnosticsContext.Set("loggerConnection", $"{loggerConnection}Logger");

            var logger = LogManager.LoadConfiguration("nlog.config")
                                   .Setup()
                                   .SetupExtensions(ext => ext.RegisterConfigSettings(configLogger))
                                   .GetCurrentClassLogger();

            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.RespectBrowserAcceptHeader = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "help";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API Sales SOLID Sample");
                c.InjectStylesheet("../css/swagger.min.css");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
