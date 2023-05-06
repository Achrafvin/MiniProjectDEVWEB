using AppStore.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppStore.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            return View(DbLocal.products);
        }


        // GET: Product/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            for(int i = 0; i < DbLocal.products.Count; i++)
            {
                if (DbLocal.products[i].IdProd == id)
                {
                    return View(DbLocal.products[i]);
                }
            }

            return View();

        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdProd,Nom,TypeProd,Price,Qstock,Image")]  Product product, HttpPostedFileBase file)
        {
            
            string path = Server.MapPath("~/Img");
            if(file==null)
            {
                product.ErrorMessage = "Please Select a file";
                ViewBag.error = product.ErrorMessage;
                return View();
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fullpath = Path.Combine(path, fileName);
                file.SaveAs(fullpath);
                product.Image = "/Img/" + fileName;
            }
            
            
            foreach (Product p in DbLocal.products) 
            {
                if (p.IdProd == product.IdProd)
                {
                    product.ErrorMessage = "Id Already Exists";
                    ViewBag.Alert = product.ErrorMessage;
                    return View();
                }
            }
            
            product.dAjoute = DateTime.Now;
            DbLocal.products.Add(product);

            
            return RedirectToAction("Index", "Product");
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foreach(Product p in DbLocal.products)
            {
                if (p.IdProd==id)
                {
                   return View(p);
                }
            }

            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Nom,TypeProd,Price,Qstock")] Product product)
        {

            if (!ModelState.IsValid)
            {
               foreach(Product p in DbLocal.products)
                {
                    if (p.IdProd == product.IdProd)
                    {
                        DbLocal.products.Add(product);
                        return RedirectToAction("Index", "Product");
                    }
                }
            }
            return View();
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            for (int i = 0; i < DbLocal.products.Count; i++)
            {
                if (DbLocal.products[i].IdProd == id)
                {
                    DbLocal.products.Remove(DbLocal.products[i]);
                }
            }

            return RedirectToAction("Index");
        }

        //POST: Product/Delete/5
        //[HttpPost]
        //public ActionResult DeleteConfirmed(int? prod)
        //{
        //    for (int i = 0; i < DbLocal.products.Count; i++)
        //    {
        //        if (DbLocal.products[i].IdProd == prod)
        //        {
        //            DbLocal.products.Remove(DbLocal.products[i]);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
