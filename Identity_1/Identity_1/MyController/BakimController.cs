using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class BakimController : Controller
    {
        
        private readonly Ihelper<Hayvan> Ihayvan;
        private readonly Ihelper<Bakim> Ibakim;



        public BakimController(Ihelper<Hayvan> hayvanHelper, Ihelper<Bakim> bakimHelper)
        {
            
            Ihayvan = hayvanHelper;
            Ibakim = bakimHelper;

        }
        // GET: BakimController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BakimController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BakimController/Create
        public ActionResult Create(int id)
        {
            string isim = Ihayvan.Find(id).Isim;
            ViewData["HayvanIsim"] = isim;
            ViewData["HayvanId"] = id;
            return View();
        }

        // POST: BakimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bakim collection)
        {
            try
            {
                Ibakim.Add(collection);
                return RedirectToAction("Details", "Hayvan", new { id = collection.HayvanID });
            }
            catch
            {
                return View();
            }
        }

        // GET: BakimController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BakimController/Edit/5
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

        // GET: BakimController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BakimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var a = Ibakim.Find(id);
            if (a == null)
            {
                return NotFound();
            }

            Ibakim.delete(a.BakimID);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
