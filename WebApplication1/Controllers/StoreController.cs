using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            Brand brand = new Brand { Name = "Yves Rocher" };
            var products = new List<Product>();
            for(int i = 0; i < 10; i++)
            {
                products.Add(new Product { Name = "product" + i });
            }
            var viewModel = new BrandProductViewModel
            {
                Brand = brand,
                Products = products
            };
            return View(viewModel);
        }
        //iskreiraj search 
        public ActionResult ShowSearch()
        {
            return View();
        }
        public ActionResult Search(string q)
        {
            var products = new List<Product>();
            products.Add(new Product { Name = "Clean and clear" });
            products.Add(new Product { Name = "Cicaplast baum" });
            products.Add(new Product { Name = "Refresh and renew" });
            products.Add(new Product { Name = "Skin goddess" });
            products.Add(new Product { Name = "Pearl skin" });
            products.Add(new Product { Name = "Dose of vitamins" });
            products.Add(new Product { Name = "Effaclar" });
            var result = new List<Product>();
            foreach(Product p in products)
            {
                if (p.Name.Contains(q))
                {
                    result.Add(p);
                }
            }
            return View(result);
        }
    }
}