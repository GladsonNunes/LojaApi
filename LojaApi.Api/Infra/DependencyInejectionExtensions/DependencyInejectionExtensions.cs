using LojaApi.Domain;
using System.Reflection;

namespace LojaApi.Api.Infra.DependencyInejectionExtensions
{
    public static class DependencyInejectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                Assembly.Load("LojaApi.Application"),
                Assembly.Load("LojaApi.Domain"),
                Assembly.Load("LojaApi.Repository")
            };

            foreach (var assembly in assemblies)
            {
                RegisterByPrefix(services, assembly, "IAplic", "Aplic");
                RegisterByPrefix(services, assembly, "IServ", "Serv");
                RegisterByPrefix(services, assembly, "IRep", "Rep");  
            }
        }

        private static void RegisterByPrefix(IServiceCollection services, Assembly assembly, string interfacePrefix, string classPrefix)
        {

            var types = assembly.GetTypes()
                .Where(t => t.IsClass
                && !t.IsAbstract
                && t.Name.StartsWith(classPrefix)
                && !t.Name.EndsWith("RepCore`1")
                && !t.Name.EndsWith("ServCore`1"))
                .ToList();

            foreach (var type in types)
            {
                
                var interfaceType = type.GetInterfaces()
                .FirstOrDefault(i => i.Name.StartsWith(interfacePrefix));

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }


            }
        }
    }
}
