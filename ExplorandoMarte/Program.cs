using ExplorandoMarte.Commands;
using ExplorandoMarte.Controllers;
using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Invokers;
using ExplorandoMarte.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExplorandoMarte.View;
using ExplorandoMarte.Configuration;

namespace ExplorandoMarte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IHost _host = Host.CreateDefaultBuilder(args)
            //    .ConfigureServices((hostContext, services) =>
            //    {
            //        services.ResolveDependencies();
            //    })
            //    .Build();

            //var app = _host.Services.GetService<IApplication>();

            //app.Run();

            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((services) =>
            {
                services.ResolveDependencies();
            });

            var app = builder.Build();

            app.Services.GetService<IApplication>().Run();
        }

    }
}