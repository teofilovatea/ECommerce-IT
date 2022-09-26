using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}