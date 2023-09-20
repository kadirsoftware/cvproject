using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Ad = p.Ad;
            hakkimda.Soyad = p.Soyad;
            hakkimda.Adres = p.Adres;
            hakkimda.Aciklama = p.Aciklama;
            hakkimda.Mail = p.Mail;
            hakkimda.Resim = p.Resim;
            hakkimda.Telefon = p.Telefon;
            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}