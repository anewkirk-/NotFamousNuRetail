using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuRetail_NotFamous.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public Decimal Freight { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DateShipped { get; set; }
        public int ShippedFromWarehouse { get; set; }
        public int OrderId { get; set; }
    }
}
