using ExplorandoMarte.Controllers;
using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using ExplorandoMarte.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ExplorandoMarte.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IController, Controller>();
            services.AddScoped<ILogger, Logger>();
            services.AddSingleton<IApplication, Application>();

            return services;
        }
    }
}
