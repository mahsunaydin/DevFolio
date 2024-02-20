using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ServiceController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService t)
        {
            db.TblService.Add(t);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService t)
        {
            var value = db.TblService.Find(t.ServiceID);
            value.ServiceTitle = t.ServiceTitle;
            //value.ServiceImageURL = t.ServiceImageURL;
            value.Description = t.Description;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }





    }
}