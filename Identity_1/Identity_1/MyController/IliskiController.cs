using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class IliskiController : Controller
    {
        private readonly Ihelper<Iliski> iliski;
        private readonly Ihelper<Hayvan> Ihayvan;
        private readonly Ihelper<Tur> Itur;
        private readonly Ihelper<Cins> Icins;

        public IliskiController(Ihelper<Iliski> Iliski, Ihelper<Hayvan> hayvanHelper, Ihelper<Tur> turHelper, Ihelper<Cins> cinsHelper)
        {
            iliski = Iliski;
            Ihayvan = hayvanHelper;
            Itur = turHelper;
            Icins = cinsHelper;
        }
        // GET: IliskiController
        public ActionResult Index()
        {
            return View(iliski.getAllData());
        }

        // GET: IliskiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult iliskiSec(int id)
        {
            ViewData["Id"] = id;
            return View();
        }
        

        // GET: IliskiController/Create
        public ActionResult AnneCreate(int hayvanId)
        {
            int cinsId = Ihayvan.Find(hayvanId).CinsId.Value;
            ViewBag.HayvanId = hayvanId;
            ViewBag.CinsId = cinsId;

            // Cinsiyeti "Dişi" olan ve CinsId'si belirtilen hayvanları al
            var dişiHayvanlar = Ihayvan.getAllData()
                .Where(h => h.CinsId == cinsId && h.Cinsiyet == "Dişi")
                .Select(h => new { h.HayvanId, h.Isim })
                .ToList();

            // Dişi hayvanları ViewBag'e ekle
            ViewBag.DisiHayvanlar = new SelectList(dişiHayvanlar, "HayvanId", "Isim");

            return View();
        }

        // POST: IliskiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnneCreate(int hayvan1Id, int hayvan2Id, IliskiTur iliskiTuru)
        {
            try
            {
                Iliski i = new Iliski
                {
                    Hayvan1Id = hayvan1Id,
                    Hayvan2Id = hayvan2Id,
                    IliskiTuru = iliskiTuru
                };
                iliski.Add(i);
                var hayvan = Ihayvan.Find(hayvan1Id);
                return RedirectToAction("iliskiSec", "Iliski", new { id = hayvan.HayvanId });
            }
            catch
            {
                ViewBag.HayvanId = hayvan1Id;
                ViewBag.CinsId = Ihayvan.Find(hayvan1Id).CinsId;
                var dişiHayvanlar = Ihayvan.getAllData()
                    .Where(h => h.CinsId == ViewBag.CinsId && h.Cinsiyet == "Dişi")
                    .Select(h => new { h.HayvanId, h.Isim })
                    .ToList();
                ViewBag.DisiHayvanlar = new SelectList(dişiHayvanlar, "HayvanId", "Isim");

                return View();
            }
        }
        public ActionResult BabaCreate(int hayvanId)
        {
            int cinsId = Ihayvan.Find(hayvanId).CinsId.Value;
            // Hayvan1Id ve CinsId'yi ViewBag'e ekle
            ViewBag.HayvanId = hayvanId;
            ViewBag.CinsId = cinsId;

            // Cinsiyeti "Erkek" olan ve CinsId'si belirtilen hayvanları al
            var erkekHayvanlar = Ihayvan.getAllData()
                .Where(h => h.CinsId == cinsId && h.Cinsiyet == "Erkek")
                .Select(h => new { h.HayvanId, h.Isim })
                .ToList();

            // Erkek hayvanları ViewBag'e ekle
            ViewBag.ErkekHayvanlar = new SelectList(erkekHayvanlar, "HayvanId", "Isim");

            return View();
        }

        // POST: IliskiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BabaCreate(int hayvan1Id, int hayvan2Id, IliskiTur iliskiTuru)
        {
            try
            {
                Iliski i = new Iliski
                {
                    Hayvan1Id = hayvan1Id,
                    Hayvan2Id = hayvan2Id,
                    IliskiTuru = iliskiTuru
                };
                iliski.Add(i);
                var hayvan = Ihayvan.Find(hayvan1Id);
                return RedirectToAction("iliskiSec", "Iliski", new { id = hayvan.HayvanId });
            }
            catch
            {
                ViewBag.HayvanId = hayvan1Id;
                ViewBag.CinsId = Ihayvan.Find(hayvan1Id).CinsId;
                var erkekHayvanlar = Ihayvan.getAllData()
                    .Where(h => h.CinsId == ViewBag.CinsId && h.Cinsiyet == "Erkek")
                    .Select(h => new { h.HayvanId, h.Isim })
                    .ToList();
                ViewBag.ErkekHayvanlar = new SelectList(erkekHayvanlar, "HayvanId", "Isim");

                return View();
            }
        }

        // GET: IliskiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IliskiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IliskiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IliskiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

