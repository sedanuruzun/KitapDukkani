﻿ 
using KitapDükkanı.Models;
using KitapDükkanı.utility;
using Microsoft.AspNetCore.Mvc;

namespace KitapDükkanı.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;

        public KitapTuruController (UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            
            List<KitapTuru> objKitapTuruList = _uygulamaDbContext.KitapTurleri.ToList();
            return View(objKitapTuruList);
        }
        public IActionResult Ekle()
        {
            var model = new KitapTuru();
            return View(); 
        }
        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {

            if (ModelState.IsValid)
            {

                _uygulamaDbContext.KitapTurleri.Add(kitapTuru);
                _uygulamaDbContext.SaveChanges();
                TempData["basarili"] = "Yeni Kitap türü basarıyla oluşturuldu";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id ==0)
            {
                return NotFound(); 
            }
            KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id); 
            if (kitapTuruVt == null) 
            {
                return NotFound();
            }
            var model = new KitapTuru();
            return View(kitapTuruVt);
        }
        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {

            if (ModelState.IsValid)
            {

                _uygulamaDbContext.KitapTurleri.Update(kitapTuru);
                _uygulamaDbContext.SaveChanges();
                TempData["basarili"] = "Yeni Kitap türü basarıyla güncellendi";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            var model = new KitapTuru();
            return View(kitapTuruVt);
        }
        [HttpPost , ActionName("Sil")]
        public IActionResult SilPOSt(int? id)
        {
            KitapTuru? kitapTuru = _uygulamaDbContext.KitapTurleri.Find(id);
            if(kitapTuru == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.KitapTurleri.Remove(kitapTuru);
            _uygulamaDbContext.SaveChanges();
            TempData["basarili"] = "Kitap türü basarıyla silindi";
            return RedirectToAction("Index", "KitapTuru");
        }

    }
}
