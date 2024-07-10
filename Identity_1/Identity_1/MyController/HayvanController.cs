using Identity_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class HayvanController : Controller
    {
        private readonly Ihelper<Iliski> iliski;
        private readonly IWebHostEnvironment webHost;
        private readonly Ihelper<Hayvan> Ihayvan;
        private readonly Ihelper<Tur> Itur;
        private readonly Ihelper<Cins> Icins;
        private readonly Ihelper<Asi> Iasi;
        private readonly Ihelper<Bakim> Ibakim;


        public HayvanController(Ihelper<Iliski> Iliski, IWebHostEnvironment webHost, Ihelper<Hayvan> hayvanHelper, Ihelper<Tur> turHelper, Ihelper<Cins> cinsHelper, Ihelper<Asi> asiHelper, Ihelper<Bakim> bakimHelper)
        {
            iliski = Iliski;
            this.webHost = webHost;
            Ihayvan = hayvanHelper;
            Itur = turHelper;
            Icins = cinsHelper;
            Iasi= asiHelper;
            Ibakim = bakimHelper;

        }

        // GET: HayvanController
        public ActionResult Index()
        {
            var hayvanlar = Ihayvan.getAllData();
            foreach (var hayvan in hayvanlar)
            {
                hayvan.Tur = Itur.Find(hayvan.TurId.Value);
                hayvan.Cins = Icins.Find(hayvan.CinsId.Value);
            }
            return View(hayvanlar);
        }

        public ActionResult Details1(int id)
        {
            var hayvan = Ihayvan.Find(id);

            if (hayvan == null)
            {
                return NotFound();
            }

            var viewModel = new HayvanDetailsViewModel
            {
                Hayvan = hayvan
            };

            // IliskiController örneğini ViewData üzerinden geçelim
            ViewData["HayvanController"] = this;

            return View(viewModel);


        }

        // GET: HayvanController/Details/5
        public ActionResult Details(int id)
        {
            var hayvan = Ihayvan.Find(id);

            if (hayvan == null)
            {
                return NotFound();
            }

            var viewModel = new HayvanDetailsViewModel
            {
                Hayvan = hayvan
            };

            // IliskiController örneğini ViewData üzerinden geçelim
            ViewData["HayvanController"] = this;

            return View(viewModel);


        }



        public Hayvan GetEbeveyn(int hayvanId, IliskiTur iliskiTuru)
        {
            var i = iliski.getAllData().FirstOrDefault(i => i.Hayvan1Id == hayvanId && i.IliskiTuru == iliskiTuru);
            return i != null ? Ihayvan.getAllData().FirstOrDefault(h => h.HayvanId == i.Hayvan2Id) : null;
        }

        private List<Hayvan> GetAtalar(int hayvanId, IliskiTur iliskiTuru)
        {
            List<Hayvan> atalar = new List<Hayvan>();
            Hayvan currentHayvan = GetEbeveyn(hayvanId, iliskiTuru);

            while (currentHayvan != null)
            {
                atalar.Add(currentHayvan);
                currentHayvan = GetEbeveyn(currentHayvan.HayvanId, iliskiTuru);
            }

            return atalar;
        }


        // GET: HayvanController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HayvanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Isim, string UserId, int Yas, string Cinsiyet, int TurId, int CinsId,
            IFormFile Resim1, DateTime DogumTarihi, DateTime OlumTarihi, IFormFile Resim2, IFormFile Resim3)
        {
            try
            {
                var resimName = "";
                var resimName2 = "";
                var resimName3 = "";
                if (Resim1?.FileName != null)
                {
                    var Root = Path.Combine(webHost.WebRootPath, "img\\hayvan");
                    resimName = Guid.NewGuid() + "-" + Resim1.FileName;
                    resimName2 = Guid.NewGuid() + "-" + Resim2.FileName;
                    resimName3 = Guid.NewGuid() + "-" + Resim3.FileName;
                    var fullPath = Path.Combine(Root, resimName);
                    var fullPath2 = Path.Combine(Root, resimName2);
                    var fullPath3 = Path.Combine(Root, resimName3);
                    Resim1.CopyTo(new FileStream(fullPath, FileMode.Create));
                    Resim2.CopyTo(new FileStream(fullPath2, FileMode.Create));
                    Resim3.CopyTo(new FileStream(fullPath3, FileMode.Create));
                }



                Hayvan h = new Hayvan()
                {

                    Isim = Isim,
                    UserId = UserId,
                    Yas = Yas,
                    Cinsiyet = Cinsiyet,
                    TurId = TurId,
                    CinsId = CinsId,

                    DogumTarihi = DogumTarihi,
                    OlumTarihi = OlumTarihi,
                    Resim1 = resimName,
                    Resim2 = resimName2,
                    Resim3 = resimName3

                };
                Ihayvan.Add(h);
                return RedirectToAction("iliskiSec", "Iliski", new { id = h.HayvanId });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create2(int id)
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
        // GET: HayvanController/Edit/5

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var h = Ihayvan.Find(id);
            if (h == null)
            {
                return NotFound();
            }

            // Tur ve Cins listelerini ViewData ile geçiyoruz
            ViewData["Turler"] = Itur.getAllData();
            ViewData["Cinsler"] = Icins.getAllData();

            return View(h);
        }

        // POST: HayvanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hayvan hayvan)
        {
            if (id != hayvan.HayvanId)
            {
                return NotFound();
            }
                try
                {
                    Ihayvan.Edit(id, hayvan);
                }
                catch (Exception ex)
                {
                    if (Ihayvan.Find(hayvan.HayvanId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Bir hata oluştu: {ex.Message}");
                    }
                }
                return RedirectToAction(nameof(Index));
            


            
        }


        // GET: HayvanController/Delete/5
        public ActionResult Delete(int id)
        {
            var hayvan = Ihayvan.Find(id);

            return View(hayvan);
        }

        // POST: TurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var hayvan = Ihayvan.Find(id);

                // İlgili aşı bilgilerini sil
                var asilar = Iasi.getAllData().Where(a => a.HayvanID == id).ToList();
                foreach (var asi in asilar)
                {
                    Iasi.delete(asi.AsiID);
                }
                var bakimlar = Ibakim.getAllData().Where(a => a.HayvanID == id).ToList();
                foreach (var bakim in bakimlar)
                {
                    Ibakim.delete(bakim.BakimID);
                }

                // İlgili ilişki bilgilerini sil
                var iliskiler = iliski.getAllData().Where(i => i.Hayvan1Id == id || i.Hayvan2Id == id).ToList();
                foreach (var item in iliskiler)
                {
                    iliski.delete(item.IliskiId);
                }

                Ihayvan.delete(hayvan.HayvanId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
