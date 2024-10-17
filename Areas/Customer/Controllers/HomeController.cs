using DataAcess.IRespositery;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;
using System.Diagnostics;
using System.Security.Claims;



namespace E_Commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUniteOfWork _uniteOfWork;

        public HomeController(ILogger<HomeController> logger , IUniteOfWork uniteOfWork)
        {
            _logger = logger;
            _uniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<products> productlist = _uniteOfWork.product.GetAll(includeProperties: "Category");
            return View(productlist);
        }
        
        public IActionResult Details(int productId)
        {
           products product =_uniteOfWork.product.Get(u=>u.Id==productId, includeProperties: "Category");
            return View(product);
        }
      
       



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
