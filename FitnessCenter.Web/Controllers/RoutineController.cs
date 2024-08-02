using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class RoutineController : Controller
    {


        [HttpGet]
        public IActionResult ListRoutines()
        {
            return View();
        }
        // GET: RoutineController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoutineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoutineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoutineController/Create
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

        // GET: RoutineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoutineController/Edit/5
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

        // GET: RoutineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoutineController/Delete/5
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
