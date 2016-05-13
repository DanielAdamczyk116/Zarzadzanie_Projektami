using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zarzadzanie_Projektami.DAL;
using Zarzadzanie_Projektami.ViewModel;

namespace Zarzadzanie_Projektami.Controllers
{
    public class HomeController : Controller
    {
        private ProjektContext db = new ProjektContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from profil in db.Profil
                                                   group profil by profil.DataUtworzeniaKonta into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       DataUtworzenia = dateGroup.Key,
                                                       ProfilCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}