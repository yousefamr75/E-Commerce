using DataAcess.IRespositery;
using DataAcess.Repositery;
using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Models;
using Models.Models.ViewModels;
using System.Collections.Generic;
using System.IO;
using Unitily;



namespace E_Commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
    

        public CompanyController(IUniteOfWork uniteOfWork )
        {
            _uniteOfWork = uniteOfWork;
           
        }
        public IActionResult Index()
        {
           
            List<Company> objProducts = _uniteOfWork.Company.GetAll().ToList();
           

            return View(objProducts);
        }
        public IActionResult Upsert(int? Id) 
        {
           
            if (Id==null || Id==0)
            {
                return View(new Company());
            }
            else
            {
               Company companyobj = _uniteOfWork.Company.Get(u => u.Id == Id);
                return View(companyobj);
            }
            

        }
        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
             
            
                if (company.Id==0)
                {
                    _uniteOfWork.Company.add(company);

                }
                else
                {
                    _uniteOfWork.Company.Update(company);
                }


           
               
                _uniteOfWork.save();

                return RedirectToAction("Index");

            }
            else
            {


      


                return View(company);

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
            Company? company = _uniteOfWork.Company.Get(u => u.Id == id);
            if (id == null)
            {
                return NotFound();

            }
            _uniteOfWork.Company.remove(company);
            _uniteOfWork.save();

            return RedirectToAction("Index");



        }
        

    }
}
