using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AdminCareerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCareer
        public ActionResult Index()
        {
            return View(db.Careers.ToList());
        }

        // GET: AdminCareer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCareer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CareerId,Title,Description,RequiredStudies,InDemand,UpdatedDate")] Career career)
        {
            if (ModelState.IsValid)
            {
                career.UpdatedDate = DateTime.Now;
                db.Careers.Add(career);
                db.SaveChanges();
                return RedirectToAction("Index", "StudentCareer");
            }
            return View(career);
        }

        // Implement Edit, Update, Delete similarly
    }
}