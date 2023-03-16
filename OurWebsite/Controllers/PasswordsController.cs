using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OurWebsite.Controllers
{
    public class PasswordsController : Controller
    {
        // GET: PasswordsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PasswordsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PasswordsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasswordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckPassword(int password)
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

        // GET: PasswordsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PasswordsController/Edit/5
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

        // GET: PasswordsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PasswordsController/Delete/5
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
