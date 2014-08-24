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
        public int SelectedPurchaseOrder { get; set; }

        public MainWindow()
        {
<<<<<<< HEAD
            InitializeComponent();            
=======
            InitializeComponent();
            CurrentQueryManager = (QueryManager)FindResource("QManager");
            StatusTextBlock.DataContext = CurrentQueryManager;
            SetPurchaseDetGridLines();
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
                PurchaseOrderDetail pd = CurrentQueryManager.QueryPurchaseOrderDetail(p.Id);
                FullPurchaseInfo fpi = new FullPurchaseInfo(p, pd);
                PurchaseDetailGrid.DataContext = fpi;
                WindowTabControl.SelectedIndex = 3;
            }
            
>>>>>>> 66e11ae9ca900595ff3ddd892e76309ab1320a53
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

        private void SetPurchaseDetGridLines()
        {
            SolidColorBrush b = new SolidColorBrush(Colors.Black);
            for (int i = 0; i < 11; i++)
            {
                Rectangle r = new Rectangle();
                r.Stroke = b;
                r.StrokeThickness = 0.1;
                PurchaseDetailGrid.Children.Add(r);
                Grid.SetRow(r, i);
                Grid.SetColumn(r, 0);

                Rectangle r2 = new Rectangle();
                r2.Stroke = b;
                r2.StrokeThickness = 0.1;
                PurchaseDetailGrid.Children.Add(r2);
                Grid.SetRow(r2, i);
                Grid.SetColumn(r2, 1);
            }
        }
    }
}
