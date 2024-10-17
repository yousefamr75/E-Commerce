using DataAcess.IRespositery;
using DataAcess.Repositery;
using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unitily;

namespace E_Commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =Sd.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        public CategoryController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _uniteOfWork.Category.GetAll().ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder Cannot exactly Match The Name ");

            }
            if (ModelState.IsValid)
            {
                _uniteOfWork.Category.add(obj);
                _uniteOfWork.save();

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Edite(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Category category = _uniteOfWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult Edite(Category obj)
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.Category.Update(obj);
                _uniteOfWork.save();

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Category category = _uniteOfWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            Category? obj = _uniteOfWork.Category.Get(u => u.Id == id);
            if (id == null)
            {
                return NotFound();

            }
            _uniteOfWork.Category.remove(obj);
            _uniteOfWork.save();

            return RedirectToAction("Index");



        }

    }
}
