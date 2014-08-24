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
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SupplierName { get; set; }
        public double TotalCost { get; set; }
        public string Status { get; set; }
        public string ShippedToWarehouse { get; set; }
    }
}
