using BancoBitcoin.Application.Util;
using Microsoft.AspNetCore.Builder;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BancoBitcoin.Api.Configuration
{
    public static class SimpleInjectorContainerConfig
    {
        public static Container InitializeComponents(this Container container, IApplicationBuilder app)
        {
            RegisterTypes(container);
            container.RegisterMvcControllers(app);
            container.AutoCrossWireAspNetComponents(app);
            container.Verify();

            return container;
        }

        public static void RegisterTypes(this Container container)
        {
            // Register all Interfaces of Repositories && Services
            var repositoryAssembly = typeof(PredicateBuilder).Assembly;
            List<Type> types = new List<Type>();

            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly.FullName.Contains("BancoBitcoin.Repository") || assembly.FullName.Contains("BancoBitcoin.Application"))
                {
                    types.AddRange(assembly.GetExportedTypes());
                }
            }

            var repositoriesRegistrations =
                from type in types
                where type.GetInterfaces().Any()
                select new { Interface = type.GetInterfaces().Single(), Implementation = type };

            repositoriesRegistrations.ToList().ForEach(repository =>
                container.Register(repository.Interface, repository.Implementation, Lifestyle.Scoped)
            );
        }
    }
}
