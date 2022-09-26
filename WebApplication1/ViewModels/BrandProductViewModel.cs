using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class BrandProductViewModel
    {
        public Brand Brand { get; set; }
        public List<Product> Products{ get; set; }
        //treba constructor da stavis ovde?


    }
}