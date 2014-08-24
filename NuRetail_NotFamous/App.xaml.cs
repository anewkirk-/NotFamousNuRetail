using NuRetail_NotFamous.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NuRetail_NotFamous
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit_1(object sender, ExitEventArgs e)
        {
            QueryManager q = (QueryManager)FindResource("QManager");
        }
    }
}
