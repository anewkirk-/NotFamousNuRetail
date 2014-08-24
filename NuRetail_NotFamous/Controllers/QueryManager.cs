using MySql.Data.MySqlClient;
using NuRetail_NotFamous.Models;
using NuRetail_NotFamous.nEnums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Controllers
{
    public class QueryManager
    {
        private MySqlConnection connection = new MySqlConnection();

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

        private string vendorQuery = "";

        private string purchaseSummaryQuery = "";

        private string purchaseDetailQuery = "";


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
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        private void QueryVendors()
        {
            long Id;
            string Name;
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

            //close Data Reader
            resultReader.Close();

            //return list to be displayed
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

    }
}
