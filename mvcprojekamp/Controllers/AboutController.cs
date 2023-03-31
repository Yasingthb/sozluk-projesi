using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcprojekamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about) 
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }


    }
}