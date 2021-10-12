using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvvmDiLog.Tools
{
    public abstract class LocatorBase
    {
        protected IConfiguration Configuration { get; private set; }
        internal IServiceProvider Container { get; init; }

        protected LocatorBase()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("App.config", optional: true, reloadOnChange: true);
            Configuration = builder.Build();             

            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Container = services.BuildServiceProvider();            
        }

        protected abstract void ConfigureServices(IServiceCollection services);
    }
}
