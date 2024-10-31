using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class StudentCareerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Career
        public ActionResult Index()
        {
            var careers = db.Careers.OrderByDescending(c => c.UpdatedDate).ToList();
            return View(careers);
        }

        // GET: Career/Details/5
        public ActionResult Details(int id)
        {
            var career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }
     

     

        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var careers = db.Careers
                .Where(c => c.Title.Contains(keyword) || c.RequiredStudies.Contains(keyword))
                .ToList();

            return View(careers);  // Assuming you have a view to display the results
        }

    }
}