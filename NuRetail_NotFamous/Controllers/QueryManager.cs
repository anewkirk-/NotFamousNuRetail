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
        string ConnectionURL = @"server=localhost; Port=3306; database=nuretail; user=notfamous;
            password=firemonkey";
        MySqlConnection connection = new MySqlConnection();

        public void Test()
        {

            try
            {
                connection = new MySqlConnection(ConnectionURL);
                connection.Open();
                Console.WriteLine("MySQL version :" + connection.ServerVersion.ToString());

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

                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        MySqlDataReader read = null;
        MySqlConnection connect = null;
        MySqlCommand command = null;

        private ObservableCollection<PurchaseOrderDetail> _PurchaseOD;

        public ObservableCollection<PurchaseOrderDetail> PurchaseOD
        {
            get { return _PurchaseOD; }
            set { _PurchaseOD = value; }
        }

        private void QueryPurchaseOrderDetails()
        {
            string Sku;
            string Name;
            int Quantity;
            double UnitCost;
            double ExtendedCost;

            while(read.Read())
            {

            }
            string SkuCommand = "SELECT" +
                                 "FROM" +
                                 "WHERE";
            command = new MySqlCommand(SkuCommand);
            command.Connection = connect;
            string NameCommand = "SELECT" +
                                "FROM" +
                                "WHERE";
            command = new MySqlCommand(NameCommand);
            command.Connection = connect;
            string QuantityCommand = "SELECT" +
                                "FROM" +
                                "WHERE";
            command = new MySqlCommand(QuantityCommand);
            command.Connection = connect;
            string UnitCostCommand = "SELECT" +
                                "FROM" +
                                "WHERE";
            command = new MySqlCommand(UnitCostCommand);
            command.Connection = connect;
            string ExtendedCostCommand = "SELECT" +
                                "FROM" +
                                "WHERE";
            command = new MySqlCommand(ExtendedCostCommand);
            command.Connection = connect;
        }


        private void QueryPurchaseOrderSummary()
        {
            long Id;
            string Date;
            Vendor Supplier;
            double TotalCost;
            PurchaseOrderStatus Status;
            Warehouse ShippedToWareouse;
        }

        private void QueryVendor()
        {
            long Id;
            string Name;
        }

        private void QueryWarehouse()
        {
            long Id;
            string Name;
            string Address;
        }
    }
}
