using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace DemoMvvmDiLog.Tools
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDispatcher(this IServiceCollection services)
        {
            services.AddSingleton(sp => Application.Current.Dispatcher);
            return services;
        }

        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            IEnumerable<AssemblyName> assemblyNames = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()                
                .Union(new AssemblyName[] { Assembly.GetExecutingAssembly().GetName() }).ToList();

            foreach(AssemblyName assemblyName in assemblyNames)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                IEnumerable<Type> viewTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Window)) && t != typeof(NavigationWindow));

                foreach(Type viewType in viewTypes)
                {                    
                    services.AddTransient(viewType);
                }
            }

            return services;
        }
    }
}
