using Microsoft.AspNetCore.Builder;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BancoBitcoin.Repository;

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
            // UnitOfWork -------
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            // Repositories -------
            //var repositoryAssembly = typeof(IUnitOfWork).Assembly;
            var repositoryAssembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.FullName.Contains("BancoBitcoin.Repository"));
            //var repositoryAssembly = Assembly.LoadFrom("BancoBitcoin.Repository.dll"); //AppDomain.GetAssemblies();// CurrentDomain.GetAssemblies().SingleOrDefault(x => x.FullName.Contains("BancoBitcoin.Repository"));

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "BancoBitcoin.Repository"
                    select t;

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //List<Assembly> myAssemblies = new List<Assembly>();

            //foreach (Assembly assembly in assemblies)
            //{
            //    if (assembly.GetName().Name.Contains("Repository") && assembly.GetName().Name.Contains("Application"))
            //        myAssemblies.Add(assembly);
            //}

            var repositoriesRegistrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.GetInterfaces().Any()
                //where !type.Namespace.StartsWith("BancoBitcoin.Repository.Interface")
                //where !type.Namespace.StartsWith("BancoBitcoin.Repository.Util")
                select new { Interface = type.GetInterfaces().Single(), Implementation = type };

            repositoriesRegistrations.ToList().ForEach(repository =>
                container.Register(repository.Interface, repository.Implementation, Lifestyle.Scoped)
            );

            // Services
            //container.Register<IBookService, BookService>(Lifestyle.Scoped);
            //var serviceAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("BancoBitcoin.Application")).FirstOrDefault();

            //var servicesRegistrations =
            //    from type in serviceAssembly.GetExportedTypes()
            //    where type.GetInterfaces().Any()
            //    where !type.Namespace.StartsWith("BancoBitcoin.Repository.Interface")
            //    where !type.Namespace.StartsWith("BancoBitcoin.Repository.Util")
            //    select new { Interface = type.GetInterfaces().Single(), Implementation = type };

            //servicesRegistrations.ToList().ForEach(service =>
            //    container.Register(service.Interface, service.Implementation, Lifestyle.Scoped)
            //);
        }
    }
}
