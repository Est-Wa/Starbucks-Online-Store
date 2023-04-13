using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OurWebsite.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        //public CategoriesController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}
        //// GET: CategoriesController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: CategoriesController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CategoriesController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            var ans = _categoryService.addCategory(category);
            
        }
        
        //// GET: CategoriesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CategoriesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CategoriesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CategoriesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
