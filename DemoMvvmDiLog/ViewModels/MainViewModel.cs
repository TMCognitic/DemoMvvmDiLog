using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DemoMvvmDiLog.ViewModels
{
    public class MainViewModel
    {
        private readonly ILogger _logger;
        private readonly Dispatcher _dispatcher;
        public MainViewModel(ILogger<MainViewModel> logger, Dispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
            logger.LogInformation("Test de log");            
            logger.LogInformation("Test de log2");
        }
    }
}
