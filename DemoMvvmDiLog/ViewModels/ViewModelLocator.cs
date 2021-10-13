using DemoMvvmDiLog.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoMvvmDiLog.ViewModels
{
    public class ViewModelLocator : LocatorBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddDispatcher()
                .AddViews();
            services.AddLogging(c => {
                c.SetMinimumLevel(LogLevel.Trace);
#if DEBUG
                c.AddDebug().AddConfiguration(Configuration);
                c.AddConsole().AddConfiguration(Configuration);
#else
                c.AddEventLog().AddConfiguration(Configuration);
#endif
            });
            services.AddSingleton<MainViewModel>();
        }

        public MainViewModel Main
        {
            get { return Container.GetService<MainViewModel>(); }
        }
    }
}
