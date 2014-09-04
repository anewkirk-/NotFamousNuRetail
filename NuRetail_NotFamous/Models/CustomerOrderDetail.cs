using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class CustomerOrderDetail
    {
        public CustomerOrderSummary Summary { get; set; }
        public List<Product> Products { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}
