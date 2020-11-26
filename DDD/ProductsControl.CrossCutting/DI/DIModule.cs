using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductsControl.Application.App;
using ProductsControl.Application.App.Interfaces;
using ProductsControl.Domain.Interfaces.ProductsRepository;
using ProductsControl.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProductsControl.CrossCutting.DI
{
    public static class DIModule
    {
        public static void ConfigureClassDI(IServiceCollection services) 
        {
            services.AddScoped<IProductApplication, ProductsApplication>();
            services.AddScoped<IProductsRepository, ProductsRepository>();


            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "ProductsControl.CrossCutting.Mapper");

            Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
            {
                return
                  assembly.GetTypes()
                          .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                          .ToArray();
            }

            services.AddAutoMapper(typelist);
        }
    }
}
