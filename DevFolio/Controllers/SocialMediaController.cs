using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia t)
        {
            db.TblSocialMedia.Add(t);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(values);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            return View(values);
        }
        
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia t)
        {
            var values = db.TblSocialMedia.Find(t.SocialMediaID);
            values.PlatformName = t.PlatformName;
            values.Status = t.Status;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


    }
}