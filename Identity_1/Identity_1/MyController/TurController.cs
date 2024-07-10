using Microsoft.AspNetCore.Mvc;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class TurController : Controller
    {
        private readonly Ihelper<Tur> turs;

        public TurController(Ihelper<Tur> Turs)
        {
            turs = Turs;
        }

        // GET: TurController
        public ActionResult Index()
        {
            return View(turs.getAllData());
        }

        // GET: TurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tur collection)
        {
            try
            {
                turs.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurController/Edit/5
        public ActionResult Edit(int id)
        {
            var s = turs.Find(id);
            return View(s);
        }

        // POST: TurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tur collection)
        {
            try
            {
                turs.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurController/Delete/5
        public ActionResult Delete(int id)
        {
            var s = turs.Find(id);
            return View(s);
        }

        // POST: TurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                turs.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
