using DataAcess.IRespositery;
using DataAcess.Repositery;
using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Models.Models.ViewModels;
using System.Collections.Generic;
using System.IO;
using Unitily;



namespace E_Commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.Role_Admin)]

    public class productController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public productController(IUniteOfWork uniteOfWork , IWebHostEnvironment webHostEnvironment)
        {
            _uniteOfWork = uniteOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           
            List<products> objProducts = _uniteOfWork.product.GetAll(includeProperties:"Category").ToList();
           

            return View(objProducts);
        }
        public IActionResult Upsert(int? Id) 
        {
            productsMv productsMv = new()
            {
                CategoryList = _uniteOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                products = new products()
            };
            if (Id==null || Id==0)
            {
                return View(productsMv);
            }
            else
            {
                productsMv.products = _uniteOfWork.product.Get(u => u.Id == Id);
                return View(productsMv);
            }
            

        }
        [HttpPost]
        public IActionResult Upsert(productsMv productsMv, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwRootPath=_webHostEnvironment.WebRootPath;
            if (file!=null)
            {
                string filename=Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);   
                string productpath=Path.Combine(wwRootPath, @"images");
                if (!string.IsNullOrEmpty(productsMv.products.ImageUrl))
                {
                   
                    var oldImagePath = Path.Combine(wwRootPath, productsMv.products.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStearm = new FileStream(Path.Combine(productpath, filename), FileMode.Create)) 
                {
                    file.CopyTo(fileStearm);
                }
                productsMv.products.ImageUrl = @"\images\" + filename;
            }
                if (productsMv.products.Id==0)
                {
                    _uniteOfWork.product.add(productsMv.products);

                }
                else
                {
                    _uniteOfWork.product.Update(productsMv.products);
                }


           
               
                _uniteOfWork.save();

                return RedirectToAction("Index");

            }
            else
            {


                productsMv.CategoryList = _uniteOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });


                return View(productsMv);

            }
          

        }
       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            products category = _uniteOfWork.product.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            products? obj = _uniteOfWork.product.Get(u => u.Id == id);
            if (id == null)
            {
                return NotFound();

            }
            _uniteOfWork.product.remove(obj);
            _uniteOfWork.save();

            return RedirectToAction("Index");



        }
        

    }
}
