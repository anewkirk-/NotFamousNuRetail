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
using NuRetail_NotFamous.Models;

namespace NuRetail_NotFamous
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public QueryManager CurrentQueryManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CurrentQueryManager = (QueryManager)FindResource("QManager");
        }

        private void RefreshWarehouses()
        {
            List<Warehouse> w = CurrentQueryManager.QueryWarehouses();
            WarehouseDataGrid.ItemsSource = w;
        }

        private void RefreshPurchaseSummaries()
        {
            throw new NotImplementedException();
        }

        private void RefreshVendors()
        {
            List<Vendor> v = CurrentQueryManager.QueryVendors();
            VendorsDataGrid.ItemsSource = v;
        }

        private void Refresh_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentQueryManager.IsConnectionOpen)
            {
                RefreshCurrentTab();
            }
            else
            {
                CurrentQueryManager.Open();
                Refresh_Button_Click_1(null, null);
            }
        }

        private void RefreshCurrentTab()
        {
            try
            {
                switch (WindowTabControl.SelectedIndex)
                {
                    case 0:
                        RefreshWarehouses();
                        break;
                    case 1:
                        RefreshVendors();
                        break;
                    case 2:
                        RefreshPurchaseSummaries();
                        break;
                    case 3:
                        WindowTabControl.SelectedIndex = 0;
                        throw new NotImplementedException();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occurred.\n" + e.Message);
            }
        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            TabItem selected = tc.SelectedItem as TabItem;
            RefreshCurrentTab();
        }

        private void PurchaseSumDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OpenMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentQueryManager.Open();
        }

        private void CloseMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentQueryManager.Close();
        }

        private void WarehouseQMenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            RefreshWarehouses();
        }

        private void VendorQMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshVendors();
        }


    }
}
