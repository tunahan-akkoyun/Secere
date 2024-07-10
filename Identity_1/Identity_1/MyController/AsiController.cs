using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class AsiController : Controller
    {
        private readonly Ihelper<Hayvan> Ihayvan;
        private readonly Ihelper<Asi> Iasi;



        public AsiController(Ihelper<Hayvan> hayvanHelper, Ihelper<Asi> asiHelper)
        {

            Ihayvan = hayvanHelper;
            Iasi = asiHelper;

        }
        // GET: AsiController
        public ActionResult Index()
        {
            return View(Iasi.getAllData());
        }


        public ActionResult Hayvanasi()
        {
            return View(Iasi.getAllData());
        }


        // GET: AsiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsiController/Create
        public ActionResult Create(int id)
        {
            string isim = Ihayvan.Find(id).Isim;
            ViewData["HayvanIsim"] = isim;
            ViewData["HayvanId"]=id;
            return View();
        }

        // POST: AsiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asi collection)
        {
            try
            {
                Iasi.Add(collection);

                return RedirectToAction("Details", "Hayvan", new { id =collection.HayvanID });
			}
            catch
            {
                return View();
            }
        }

        // GET: AsiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsiController/Edit/5
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

       
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
                
        //        var a = Iasi.Find(id); 
        //        if (a != null)
        //        {
        //            Iasi.delete(a.AsiID); 
                    
        //        }

        //        return Redirect(Request.Headers["Referer"].ToString());
        //    }
        //    catch
        //    {
        //        return View("Error"); 
        //    }
        //}

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var a = Iasi.Find(id);
            if (a == null)
            {
                return NotFound();
            }

            Iasi.delete(a.AsiID);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
