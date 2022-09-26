using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public ApplicationDbContext context;
            // GET: Category
            public CategoryController()
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
            var categorylist = context.Categories.ToList();
            return View(categorylist);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateNew(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(int id)
        {
            Category c = context.Categories.Find(id);
            context.Categories.Remove(c);
            context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Edit(int id)
        {
            var category = context.Categories.Single(c => c.CategoryId == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        public ActionResult EditCategory(Category category)
        {
            
            var categoryDb = context.Categories.Single(c => c.CategoryId == category.CategoryId);
            TryUpdateModel(categoryDb);
            context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        

        }
        

    }
