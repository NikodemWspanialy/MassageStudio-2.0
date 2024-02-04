using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MassageStudio.MVC.Controllers
{
    public class MasseurController : Controller
    {
        // GET: MasseurController - list of massages
        public ActionResult Index()
        {
            return View();
        }

        // GET: MasseurController/Details/5 - szczegoly
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasseurController/Create - view
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasseurController/Create - action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: MasseurController/Edit/5 - view
        public ActionResult Edit(int id) 
        {
            return View();
        }

        // POST: MasseurController/Edit/5
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

        // GET: MasseurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasseurController/Delete/5
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
