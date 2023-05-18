using Application;
using Application.Services;
using Data;
using Domain;
using Interfaces.Application;
using Interfaces.Data;
using Interfaces.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Resolver
{
    public static class AppResolver
    {
        public static void AddServicesApp(this IServiceCollection services)
        {
            Application(services);
            Domain(services);
            Data(services);
        }

        private static void Data(IServiceCollection services)
        {
            services.AddScoped<IRepository, OrderRepository>();
        }

        private static void Domain(IServiceCollection services)
        {
            services.AddScoped<IDataTransformation, DataTransformation>();
        }
        
        private static void Application(IServiceCollection services)
        {
            services.AddScoped<IDataCreator, DataCreator> ();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}