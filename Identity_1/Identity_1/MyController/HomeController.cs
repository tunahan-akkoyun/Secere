using Identity_1.Data;
using Identity_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyClass;
using MyData.Repository;


namespace Identity_1.MyController
{
    public class HomeController : Controller
    {
        private readonly Ihelper<Iliski> iliski;
        private readonly IWebHostEnvironment webHost;
        private readonly Ihelper<Hayvan> Ihayvan;
        private readonly Ihelper<Tur> Itur;
        private readonly Ihelper<Cins> Icins;


        public HomeController(Ihelper<Iliski> Iliski, IWebHostEnvironment webHost, Ihelper<Hayvan> hayvanHelper, Ihelper<Tur> turHelper, Ihelper<Cins> cinsHelper)
        {
            iliski = Iliski;
            this.webHost = webHost;
            Ihayvan = hayvanHelper;
            Itur = turHelper;
            Icins = cinsHelper;

        }

        // GET: Home
        public ActionResult Index()
        {
            var hayvanlar = Ihayvan.getAllData();
            var random = new Random();
            hayvanlar = hayvanlar.OrderBy(x => random.Next()).ToList();
            var turler = Itur.getAllData();
            var cinsler = Icins.getAllData();
            return View(new HomeViewModel { Hayvanlar = hayvanlar, Turler = turler, Cinsler = cinsler });
        }

        public ActionResult Search(string query)
        {
            var hayvanlar = Ihayvan.getAllData().Where(h => h.Isim.Contains(query)).ToList();
            return PartialView("_HayvanList", hayvanlar);
        }

        public ActionResult GetHayvanlarByTur(int turId)
        {
            var hayvanlar = Ihayvan.getAllData().Where(h => h.TurId == turId).ToList();
            var cinsler = Icins.getAllData().Where(c => c.TurId == turId).ToList();
            return PartialView("_HayvanList", hayvanlar);
        }

        public ActionResult GetCinslerByTur(int turId)
        {
            var cinsler = Icins.getAllData().Where(c => c.TurId == turId).ToList();
            return PartialView("_CinsList", cinsler);
        }

        public ActionResult GetHayvanlarByCins(int cinsId)
        {
            var hayvanlar = Ihayvan.getAllData().Where(h => h.CinsId == cinsId).ToList();
            return PartialView("_HayvanList", hayvanlar);
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
    }
}
