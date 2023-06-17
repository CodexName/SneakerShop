using Microsoft.AspNetCore.Mvc;
using SeakerSop.Models;
using SeakerSop.Repository;

namespace SeakerSop.Controllers
{
    public class MyOrdersController : Controller
    {
        private readonly IRepository Repository;
        private readonly DbContextApplication _Context;
        public const string SessionKeyId = "IdUserKey";
        public MyOrdersController(DbContextApplication context)
        {
            _Context = context;
            Repository = new RealizationRepository(_Context);
        }
        [HttpGet]
        public IActionResult MyOrdersView()
        {
            int? idUser = HttpContext.Session.GetInt32(SessionKeyId);
            var MyOrdersView = Repository.MyOrders(idUser);
            return View("/Views/Ordering/MyOrderingStory.cshtml",MyOrdersView);
        }
           

    }
}
