using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NuRetail_NotFamous.Controllers;

namespace NuRetail_NotFamous
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public QueryManager QManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Refresh_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            TabItem selected = tc.SelectedItem as TabItem;
            //Refresh data in selected tab
        }

        private void PurchaseSumDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
