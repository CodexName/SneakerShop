using Microsoft.AspNetCore.Mvc;
using SeakerSop.Models;
using SeakerSop.Repository;

namespace SeakerSop.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository Repository;
        private readonly DbContextApplication _Context;
        private readonly IQueryable<Cart> CartViewData;
        const string IdProductKey = "IdProduct";
        public CartController(DbContextApplication context)
        {
            _Context = context;
            Repository = new RealizationRepository(_Context);
            CartViewData = Repository.ReadDataCart();
        }
        [HttpGet]
        public IActionResult CartView()
        {
            return View("/Views/CartProduct/CartView.cshtml",CartViewData);
        }
        [HttpPost]
        public IActionResult RemObject(int id)
        {
            Repository.DeleteProductCart(id);
            return RedirectToAction("CartView","Cart");
        }
        [HttpPost]
        public IActionResult OrderingProcces (int id)
        {
            HttpContext.Session.SetInt32(IdProductKey,id);
            return RedirectToAction("OrderingView", "Ordering");
        }
        

    }
}
