﻿using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {

            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var y = repo.Find(x => x.ID == t.ID);
            y.Baslik = t.Baslik;
            y.AltBaslik1 = t.AltBaslik1;
            y.AltBaslik2 = t.AltBaslik2;
            y.Tarih = t.Tarih;
            y.GNO = t.GNO;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}