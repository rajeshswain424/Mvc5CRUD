using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EfCrud.Models;

namespace EfCrud.Controllers
{
    public class ProductsController : Controller
    {
        MvcDbcontext db = new MvcDbcontext();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.tableProducts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Products products=db.tableProducts.Find(id);
            if (products == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(products);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                Products products = new Products();
                TryUpdateModel(products);
                db.tableProducts.Add(products);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Products products = db.tableProducts.Find(id);
            if (products == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(products);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditUpdate(int? id)
        {
            Products product=db.tableProducts.Find(id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id required");
            }
            Products products=db.tableProducts.Find(id);
            if (products == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");

            }

            return View(products);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Products product=db.tableProducts.Find(id);
            db.tableProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}