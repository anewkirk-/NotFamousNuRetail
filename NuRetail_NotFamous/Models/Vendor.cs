using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class Vendor
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Vendor(long id = -1, string name = "")
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
