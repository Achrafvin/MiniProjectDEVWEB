using AppStore.Models;
using System;
using System.Web.Mvc;

namespace AppStore.Controllers
{
    public class DataController : Controller
    {
       
        public ActionResult Index()
        {
            //Admin Account
            
            User user = new User();
            user.IdUser = 1;
            user.Username = "Achraf";
            user.Email = "admin@admin.com";
            user.Password = "Achraf";
            user.Role = "Admin";
            //User Account
            User user1 = new User();
            user1.IdUser = 2;
            user1.Username = "Achrafvin";
            user1.Email = "achraf@gmail.com";
            user1.Password = "aaaaaa";
            user1.Role = "user";

            //Add Data To List
            DbLocal.users.Add(user);
            DbLocal.users.Add(user1);

            //////////////////////////////////////////////////////////////

            //Data Product
            Product prod = new Product();
            prod.IdProd = 1;
            prod.Nom = "Iphone 14";
            prod.TypeProd = "Mobilite";
            prod.Price = 12000;
            prod.Qstock = 500;
            prod.dAjoute = DateTime.Now;
            prod.Image = "/Img/16482381.jpg";

            Product prod1 = new Product();
            prod1.IdProd = 2;
            prod1.Nom = "Headphones JBL";
            prod1.TypeProd = "Audio";
            prod1.Price = 1500;
            prod1.Qstock = 200;
            prod1.dAjoute = DateTime.Now;
            prod1.Image = "/Img/15458144.jpg";

            Product prod2 = new Product();
            prod2.IdProd = 3;
            prod2.Nom = "Laptop Lenovo 2022";
            prod2.TypeProd = "Informatique";
            prod2.Price = 12500;
            prod2.Qstock = 300;
            prod2.dAjoute = DateTime.Now;
            prod2.Image = "/Img/16015940.jpg";

            DbLocal.products.Add(prod);
            DbLocal.products.Add(prod1);
            DbLocal.products.Add(prod2);
            return View();
 }
    }
}