using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeakerSop.Models;
using SeakerSop.Repository;
using Microsoft.AspNetCore.Session;
using System.Text.Json;

namespace SeakerSop.Controllers
{
    public class OrderingController : Controller
    {
        private readonly IRepository Repository;
        private readonly IRepositoryPayBase PayRepository;
        private readonly DbContextApplication _Context;
        private readonly DbPayContext _ContextPay;
        const string IdProductKey = "IdProduct";
        const string IdOrderKey = "OrderKey";
        public const string SessionKeyId = "IdUserKey";
        public OrderingController(DbContextApplication context, DbPayContext dbpaycontext)
        {
            _ContextPay = dbpaycontext;
            _Context = context;
            Repository = new RealizationRepository(_Context);
            PayRepository = new RealiztionRepositoryPayBase(_ContextPay);
        }
        [HttpGet]
        public IActionResult OrderingView ()
        {      
            return View("/Views/Ordering/OrderingView.cshtml");
        }
        [HttpPost]
        public IActionResult AddDataOrderManInfo(OrderNotMap orderinfo)
        {
            if (ModelState.IsValid)
            {
                string SerializeOrder = JsonSerializer.Serialize(orderinfo);
                HttpContext.Session.SetString(IdOrderKey, SerializeOrder);
                return View("/Views/Ordering/PayView.cshtml");
            }
            return View("/Views/Ordering/OrderingView.cshtml");
        }

        [HttpGet]
        public IActionResult PayMethodView()
        {
            return View("/Views/Ordering/PayView.cshtml");
        }
        [HttpPost]
        public IActionResult AddDataPayInfo(RequisitesUser requisitpayuser)
        {
            if (ModelState.IsValid)
            {
                int? idproduct = HttpContext.Session.GetInt32(IdProductKey);
                var productsneackers = _Context.SneakersProducts.AsNoTracking().Single(x => x.Id == idproduct);
                double priceproduct = productsneackers.Price;
                foreach (var iteminfo in PayRepository.ReadData())
                {
                    if (iteminfo.CVCode == requisitpayuser.CVCode && iteminfo.CardNumber == requisitpayuser.CardNumber &&iteminfo.Date == requisitpayuser.Date)
                    {
                        
                        if (priceproduct <= iteminfo.Balance)
                        {
                            double newvaluebalanceuser = iteminfo.Balance - priceproduct;
                            PayRepository.UptadeBalanceUser(newvaluebalanceuser, iteminfo.CardNumber);
                            string DeserializeOrder = HttpContext.Session.GetString(IdOrderKey);
                            OrderNotMap notMapedDeserealize = JsonSerializer.Deserialize<OrderNotMap>(DeserializeOrder);
                            int? idUser = HttpContext.Session.GetInt32(SessionKeyId);
                            Repository.AddOrderInfo(notMapedDeserealize,idUser);
                            return View("/Views/Ordering/SuccsesfulOrdering.cshtml");
                        }
                        else
                        {
                            ModelState.AddModelError("Balance","На балансе не достаточно средств");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("CVCode", iteminfo.CVCode != requisitpayuser.CVCode ? "Не верно указан CVC код" : null);
                        ModelState.AddModelError("CardNumber", iteminfo.CardNumber != requisitpayuser.CardNumber ? "Не верно указан номер карты" : null);
                        ModelState.AddModelError("Date", iteminfo.Date != requisitpayuser.Date ? "Не верно указана дата" : null);
                        return View("/Views/Ordering/PayView.cshtml");
                    }
                }
            }
            return View("/Views/Ordering/PayView.cshtml");
        }
    }
}
