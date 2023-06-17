using Microsoft.AspNetCore.Mvc;
using SeakerSop.Models;
using SeakerSop.Repository;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace SeakerSop.Controllers
{
    public class ManProductController : Controller
    {
        private readonly IRepository Repository;
        private readonly DbContextApplication _Context;
        private readonly IQueryable<SneakersProduct> ManSneakersViewData;
        public ManProductController(DbContextApplication context)
        {
            _Context = context;
            Repository = new RealizationRepository(_Context);
            ManSneakersViewData = Repository.ReadDataSneakersMan();
        }
        public IActionResult CatalogManProductView()
        {
            var ManSneakersView = ManSneakersViewData;
            return View("/Views/ManProduct/ManProductView.cshtml", ManSneakersView);
        }
        [HttpPost]
        public IActionResult SortingProduct(string color, int price, int size)
        {
            var SortedProduct = ManSneakersViewData;
            if (color != null)
            {
                SortedProduct = ManSneakersViewData.Where(x => x.Color == color);
            }
            if (price != 0)
            {
                SortedProduct = ManSneakersViewData.Where(x => x.Price <= price);
            }
            if (size != 0)
            {
                SortedProduct = ManSneakersViewData.Where(x => x.Size == size);
            }
            return View("/Views/ManProduct/ManProductView.cshtml", SortedProduct);
        }

        [HttpPost]
        public IActionResult AddCart(string name, int size, string country, string color, int price, string pictures)
        {
            DateTime time = DateTime.Now;
            Repository.AddCartProduct(name, size, country, color, price, time, pictures);
            return View("/Views/ManProduct/ManProductView.cshtml", ManSneakersViewData);
        }
    }

}
