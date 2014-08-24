using MySql.Data.MySqlClient;
using NuRetail_NotFamous.Models;
using NuRetail_NotFamous.nEnums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Controllers
{
    public class QueryManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string connectString = @"server=localhost; Port=3306; database=nuretail; user=notfamous;
            password=firemonkey";

        private string warehouseQuery = @"select w.warehouse_id, 
	w.name, 
	concat(a.street,
		', ',
		a.city,
		', ',
		a.state,
		' ',
		a.postal_code) as address
from warehouses w, addresses a
where w.address_id = a.address_id;";

        private string vendorQuery = @"select vendor_id, vendor_name
from vendors
order by vendor_name;";

        private string purchaseSummaryQuery = "";

        private string purchaseDetailQuery = "";

        public MySqlConnection connection;

        private bool _isConnectionOpen;
        public bool IsConnectionOpen
        {
            get
            {
                return _isConnectionOpen;
            }
            set
            {
                _isConnectionOpen = value;
                FirePropertyChanged("IsConnectionOpen");
            }
        }

        public QueryManager()
        {
            connection = new MySqlConnection(connectString);
            this.Open();
        }

        public string Test()
        {
            string a = string.Empty;
            try
            {
                connection = new MySqlConnection(connectString);
                connection.Open();

                a = "Test connection successful: MySQL version :" + connection.ServerVersion.ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return a;
        }

        public void Open()
        {
            try
            {
                if (connection == null)
                {
                    connection = new MySqlConnection(connectString);
                }
                connection.Open();
                IsConnectionOpen = true;
            }
            catch (MySqlException ex)
            {
                IsConnectionOpen = false;
                Console.WriteLine(ex.ToString());
            }
        }

        public void Close()
        {
            if (connection != null)
            {
                connection.Close();
                IsConnectionOpen = false;
            }
        }

        public List<Vendor> QueryVendors()
        {
            List<Vendor> result = new List<Vendor>();

            MySqlCommand command = new MySqlCommand(vendorQuery, connection);
            MySqlDataReader resultReader = command.ExecuteReader();

            while (resultReader.Read())
            {
                Vendor current = new Vendor();
                current.Id = (int)resultReader["vendor_id"];
                current.Name = (string)resultReader["vendor_name"];
                result.Add(current);
            }
            resultReader.Close();
            return result;
        }

        public List<Warehouse> QueryWarehouses()
        {
            List<Warehouse> result = new List<Warehouse>();

            MySqlCommand command = new MySqlCommand(warehouseQuery, connection);
            MySqlDataReader resultReader = command.ExecuteReader();

            while (resultReader.Read())
            {
                Warehouse current = new Warehouse();

                current.Id = (int)resultReader["warehouse_id"];
                current.Name = (string)resultReader["name"];
                current.Address = (string)resultReader["address"];
                result.Add(current);
            }

            resultReader.Close();
            return result;
        }

        public void QueryPurchaseOrderDetails()
        {
            List<PurchaseOrderDetail> purchaseOrders = new List<PurchaseOrderDetail>();

            string Sku;
            string Name;
            int Quantity;
            double UnitCost;
            double ExtendedCost;
            
        }

        private void QueryPurchaseOrderSummaries()
        {
            long Id;
            string Date;
            Vendor Supplier;
            double TotalCost;
            PurchaseOrderStatus Status;
            Warehouse ShippedToWareouse;

            
        }

        private void FirePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
