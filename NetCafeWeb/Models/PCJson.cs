using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class PCJson

    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public PCJson(int id, String name, String description, double price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
        }

     
    }
}