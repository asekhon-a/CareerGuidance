using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser == null)
                {
                    var user = new User { Username = model.Username, Password = model.Password};
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "Username already exists.");
            }

            return View(model);
        }

        // GET: Account/Login
        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Storing the user's authentication in session
                    Session["Username"] = user.Username;
                    if (user.IsAdmin == true)
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                    else 
                    { 
                        return RedirectToAction("Index", "Home"); 
                    }

                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }

}