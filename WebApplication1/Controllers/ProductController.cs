using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ApplicationDbContext context;

        public ProductController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        public ActionResult Index()
        {
            var productlist = context.Products.ToList();
            return View(productlist);
        }
            [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        public PartialViewResult DailyDeal()
        {
            var product = GetDailyDeal();
            return PartialView("_DailyDeal", product);
        }
        private Product GetDailyDeal()
        {
            var product = context.Products.OrderBy(a => System.Guid.NewGuid()).First();
            product.Price *= 0.5m;
            return product;
        }
        public ActionResult ProductSearch(string q)
        {
            var products = GetProducts(q);
            return PartialView(products);
        }
        private List<Product> GetProducts(string searchString)
        {
            return context.Products.Where(a => a.Name.Contains(searchString)).ToList();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateNew(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
       
        public ActionResult Delete(int id)
        {
            Product p = context.Products.Find(id);
            context.Products.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
       
        public ActionResult Edit(int id)
        {
            var product = context.Products.Single(c => c.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        public ActionResult EditProduct(Product product)
        {

            var productDb = context.Products.Single(c => c.ProductId == product.ProductId);
            TryUpdateModel(productDb);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}