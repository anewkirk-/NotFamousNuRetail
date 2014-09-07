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
        public ImageFetcher CurrentImageFetcher { get; set; }
        public int SelectedPurchaseOrder { get; set; }
        public int SelectedCustomerOrder { get; set; }

        public MainWindow()
        {
            InitializeComponent();            

            InitializeComponent();
            CurrentQueryManager = (QueryManager)FindResource("QManager");
            CurrentImageFetcher = (ImageFetcher)FindResource("CImageFetcher");
            StatusTextBlock.DataContext = CurrentQueryManager;
        }

        private void RefreshProducts()
        {
            List<Product> p = CurrentQueryManager.QueryProducts();
            ProductsDataGrid.ItemsSource = p;
        }

        private void RefreshProductImages()
        {
            List<ProductImage> i = CurrentQueryManager.QueryProductImages();
            //ProductsDataGrid.ItemSource = i;
        }

        private void RefreshOrderSummaries()
        {
            List<CustomerOrderSummary> cos = CurrentQueryManager.QueryCustomerOrderSummaries();
            OrderSumDataGrid.ItemsSource = cos;
        }

        private void RefreshOrderDetail()
        {
            throw new NotImplementedException();
            //CustomerOrderSummary c = (CustomerOrderSummary)OrderSumDataGrid.SelectedItem;
            //if (c != null)
            //{
            //    SelectedCustomerOrder = c.OrderId;
            //}
        }

        private void RefreshWarehouses()
        {
            List<Warehouse> w = CurrentQueryManager.QueryWarehouses();
            WarehouseDataGrid.ItemsSource = w;
        }

        private void RefreshPurchaseSummaries()
        {
            List<PurchaseOrderSummary> w = CurrentQueryManager.QueryPurchaseOrderSummaries();
            PurchaseSumDataGrid.ItemsSource = w;
        }

        private void RefreshVendors()
        {
            List<Vendor> v = CurrentQueryManager.QueryVendors();
            VendorsDataGrid.ItemsSource = v;
        }

        private void RefreshPurchaseDetail()
        {
            PurchaseOrderSummary p = (PurchaseOrderSummary)PurchaseSumDataGrid.SelectedItem;
            if (p != null)
            {

                SelectedPurchaseOrder = p.Id;
                List<PurchaseOrderDetail> products = CurrentQueryManager.QueryPurchaseOrderDetail(p.Id);
                PurchaseInfoGrid.DataContext = p;
                PurchaseDetailGrid.ItemsSource = products;
                WindowTabControl.SelectedIndex = 3;
            }
            
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
                RefreshCurrentTab();
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
                        RefreshPurchaseDetail();
                        break;
                }
            }
            catch (Exception e)
            {
                string msg = "An error has occurred.\n" + e.Message;
                Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(msg)));
            }
        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            TabItem selected = tc.SelectedItem as TabItem;
            if (!CurrentQueryManager.IsConnectionOpen)
            {
                CurrentQueryManager.Open();
            }
            RefreshCurrentTab();
        }

        private void PurchaseSumDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            RefreshPurchaseDetail();
        }

        private void OpenMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (!CurrentQueryManager.Open())
            {
                MessageBox.Show("An error has occurred.\nCould not connect to database server.");
            }
        }

        private void CloseMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentQueryManager.Close();
        }

        private void PurchaseDetailGrid_AutoGeneratingColumn_1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch(e.Column.Header.ToString())
            {
                case "Sku":
                    e.Column.Header = "SKU";
                    break;
                case "ProductName":
                    e.Column.Header = "Product";
                    break;
                case "UnitCost":
                    e.Column.Header = "Unit Cost";
                    break;
                case "ExtendedCost":
                    e.Column.Header = "Extended Cost";
                    break;
                default:
                    break;
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
