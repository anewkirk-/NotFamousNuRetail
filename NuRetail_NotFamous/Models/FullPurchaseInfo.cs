using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class FullPurchaseInfo
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string SupplierName { get; set; }
        public double TotalCost { get; set; }
        public string Status { get; set; }
        public string ShippedToWareouse { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double ExtendedCost { get; set; }

        public FullPurchaseInfo(PurchaseOrderSummary ps, PurchaseOrderDetail pd)
        {
            this.Id = ps.Id;
            this.Date = ps.Date;
            this.SupplierName = ps.SupplierName;
            this.TotalCost = ps.TotalCost;
            this.Status = ps.Status;
            this.ShippedToWareouse = ps.ShippedToWareouse;
            this.Sku = pd.Sku;
            this.ProductName = pd.ProductName;
            this.Quantity = pd.Quantity;
            this.UnitCost = pd.UnitCost;
            this.ExtendedCost = pd.ExtendedCost;
        }
    }
}
