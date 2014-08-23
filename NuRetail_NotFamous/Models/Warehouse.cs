using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Models
{
    public class Warehouse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Warehouse(long id = -1, string name = "", string address = "")
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }
    }
}
