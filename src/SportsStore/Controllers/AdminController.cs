using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index() => View(_repository.Products);
        public ViewResult Edit(int productId) => View(_repository.Products.FirstOrDefault(p => p.ProductID == productId));
        [HttpPost]
        public IActionResult Edit(Product product){
            if (ModelState.IsValid) {
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                
                return RedirectToAction("Index");
            }else {
                return View(product);
            }
        }
    }
}
