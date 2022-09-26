using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ApplicationDbContext context;
       
        public BrandController()
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
            var brandlist = context.Brands.ToList();
            return View(brandlist);
        }
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateNew(Brand b)
        {
            context.Brands.Add(b);
            context.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Brand b = context.Brands.Find(id);
            context.Brands.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var brand = context.Brands.Single(c => c.BrandId == id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult EditBrand(Brand brand)
        {

            var brandDb = context.Brands.Single(c => c.BrandId == brand.BrandId);
            TryUpdateModel(brandDb);
            context.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }

    }
}