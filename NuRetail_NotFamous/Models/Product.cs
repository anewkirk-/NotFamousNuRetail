using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Sku { get; set; }
        public long Upc { get; set; }
        public string ProductName { get; set; }
        public double Msrp { get; set; }
        public string Description { get; set; }
        public ProductImage PrimaryImage { get; set; }
        public List<ProductImage> SecondaryImages { get; set; }
    }
}
