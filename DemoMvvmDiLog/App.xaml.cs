﻿using DemoMvvmDiLog.ViewModels;
using DemoMvvmDiLog.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoMvvmDiLog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ViewModelLocator Locator
        {
            get { return (ViewModelLocator)Resources[nameof(Locator)]; }
        }
    }
}
