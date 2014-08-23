using NuRetail_NotFamous.nEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class PurchaseOrderSummary
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public Vendor Supplier { get; set; }
        public double TotalCost { get; set; }
        public PurchaseOrderStatus Status { get; set; }
        public Warehouse ShippedToWareouse { get; set; }
    }
}
