using AppStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace AppStore.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            
            DataController data = new DataController();
            
                if (DbLocal.products.Count <=0)
                {
                data.Index();
                  }

            
            return View();

        }

        

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            
            bool ifExists = DbLocal.users.Any(x => x.Email == user.Email && x.Password==user.Password);
            if (!ifExists)
            {
                user.ErrorMessage = "Invalid Username or Password";
                return View(user);
            }
            else
            {
                

                foreach (User x in DbLocal.users)
                {

                    if (x.Email == user.Email)
                    {
                        Session["IdUser"] = user.IdUser;
                        Session["Username"] = user.Role;

                        if (x.Role == "Admin")
                        {
                            
                            return RedirectToAction("Index", "Product");
                        }
                        else
                            return RedirectToAction("Index", "Home");
                    }
                        
                }
                return View();
            }
        }




        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "Username,Email,Password")] User user)
        {
            bool alreadyExists = false;
            foreach (User x in DbLocal.users)
            {
                if (x.Email == user.Email)
                {
                    alreadyExists = true;
                }
            }
            if (alreadyExists)
            {
                ViewBag.Alert = "Email already exists.";
                return View();
            }
            else
            {
                user.Role = "user";
                DbLocal.users.Add(user);
                return RedirectToAction("Login", "Account");
            }
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }
}