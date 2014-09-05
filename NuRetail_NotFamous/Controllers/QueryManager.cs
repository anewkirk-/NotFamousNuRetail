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

//        private string connectString = @"server=localhost; Port=3306; database=nuretail; user=notfamous;
//            password=firemonkey";

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

        private string purchaseSummaryQuery = @"select p.purchase_id, 
	p.purchase_date, 
	v.vendor_name, 
	round(sum(pp.product_qty * pp.product_price),2) as total_price,
	ps.state, 
	w.name as warehouse
from purchases p,
	vendors v,
	purchase_products pp,
	warehouses w,
	purchase_states ps
where p.purchase_id = pp.purchase_id
and v.vendor_id = p.vendor_id
and w.warehouse_id = p.warehouse_id
and p.purchase_state = ps.purchase_state_id
group by p.purchase_id
order by p.purchase_date desc, v.vendor_name asc;";

        private string purchaseDetailQueryP1 = @"select p.sku, p.name as product_name, pp.product_qty, pp.product_price, (pp.product_qty * pp.product_price) as extended_price
from products p, purchase_products pp
where p.product_id = pp.product_id
and pp.purchase_id = ";

        private string purchaseDetailQueryP2 = "\norder by p.sku desc;";

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

        public bool Open()
        {
            bool result = false;
            try
            {
                if (connection == null)
                {
                    connection = new MySqlConnection(connectString);
                }
                if (!IsConnectionOpen)
                {
                    connection.Open();
                    IsConnectionOpen = true;
                }
                result = true;
            }
            catch (MySqlException ex)
            {
                IsConnectionOpen = false;
                Console.WriteLine(ex.ToString());
            }
            return result;
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

        public List<PurchaseOrderDetail> QueryPurchaseOrderDetail(int id)
        {
            List<PurchaseOrderDetail> result = new List<PurchaseOrderDetail>();

            string query = purchaseDetailQueryP1;
            query += id.ToString();
            query += purchaseDetailQueryP2;

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader resultReader = command.ExecuteReader();

            while (resultReader.Read())
            {
                PurchaseOrderDetail current = new PurchaseOrderDetail();

                current.Sku = (string)resultReader["sku"];
                current.ProductName = (string)resultReader["product_name"];
                current.Quantity = (int)resultReader["product_qty"];
                current.UnitCost = double.Parse((string)resultReader["product_price"]);
                current.ExtendedCost = (double)resultReader["extended_price"];
                result.Add(current);
            }

            resultReader.Close();
            return result;
        }

        public List<PurchaseOrderSummary> QueryPurchaseOrderSummaries()
        {
            List<PurchaseOrderSummary> result = new List<PurchaseOrderSummary>();

            MySqlCommand command = new MySqlCommand(purchaseSummaryQuery, connection);
            MySqlDataReader resultReader = command.ExecuteReader();

            while (resultReader.Read())
            {
                PurchaseOrderSummary current = new PurchaseOrderSummary();

                current.Id = (int)resultReader["purchase_id"];
                current.Date = (DateTime)resultReader["purchase_date"];
                current.SupplierName = (string)resultReader["vendor_name"];
                current.TotalCost = (double)resultReader["total_price"];
                current.Status = (string)resultReader["state"];
                current.ShippedToWarehouse = (string)resultReader["warehouse"];
                result.Add(current);
            }

            resultReader.Close();
            return result;
        }

        public List<CustomerOrderSummary> QueryCustomerOrderSummaries()
        {
            throw new NotImplementedException();
            //List<CustomerOrderSummary> result = new List<CustomerOrderSummary>();
        }

        private void FirePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        internal List<Product> QueryProducts()
        {
            throw new NotImplementedException();
        }
    }
}
