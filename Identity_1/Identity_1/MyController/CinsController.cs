using Microsoft.AspNetCore.Mvc;
using MyClass;
using MyData.Repository;

namespace Identity_1.MyController
{
    public class CinsController : Controller
    {
        private readonly Ihelper<Cins> cins;

        public CinsController(Ihelper<Cins> cins)
        {
            this.cins = cins;
        }
        // GET: CinslerController
        public ActionResult Index()
        {
            return View(cins.getAllData());
        }

        // GET: CinslerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CinslerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinslerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cins collection)
        {
            try
            {
                cins.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CinslerController/Edit/5
        public ActionResult Edit(int id)
        {
            var s = cins.Find(id);
            return View(s);
        }

        // POST: CinslerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cins collection)
        {
            try
            {
                cins.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CinslerController/Delete/5
        public ActionResult Delete(int id)
        {
            var s = cins.Find(id);
            return View(s);
        }

        // POST: CinslerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                cins.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
