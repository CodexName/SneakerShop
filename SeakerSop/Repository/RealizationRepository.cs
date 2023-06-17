using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeakerSop.Controllers;
using SeakerSop.Models;

namespace SeakerSop.Repository
{
    public class RealizationRepository : IRepository
    {
        private readonly DbContextApplication _Context;
        private readonly DbPayContext _PayContext;
        public RealizationRepository(DbContextApplication context)
        {
            _Context = context;
        }
        public void AddData(User user)
        {
            _Context.Add(user);
            _Context.SaveChanges();
        }

        public IQueryable<User> ReadDataUser()
        {

            var ReadingUser = _Context.Users.AsNoTracking().AsQueryable();
            return ReadingUser;
        }

        public IQueryable<SneakersProduct> ReadDataSneakersMan()
        {
            var ReadingManSneakers = _Context.SneakersProducts.AsNoTracking().Where(x => x.TypeSneakers == "Man").AsQueryable();
            return ReadingManSneakers;
        }

        public void AddCartProduct(string name, int size, string country, string color, int price, DateTime timeadd, string pictures)
        {
            var cartAdd = new Cart
            {
                Name = name,
                Size = size,
                Country = country,
                Price = price,
                Color = color,
                DateAdd = timeadd,
                Puctures = pictures
            };
            _Context.Add(cartAdd);
            _Context.SaveChanges();
        }

        public IQueryable<Cart> ReadDataCart()
        {
            var CartReading = _Context.Carts.AsNoTracking().AsQueryable();
            return CartReading;
        }

        public void DeleteProductCart(int id)
        {
            var deleteobject = _Context.Carts.Single(x => x.Id == id);
            _Context.Remove(deleteobject);
            _Context.SaveChanges();
        }

        public void AddOrderInfo(OrderNotMap orderinfo, int? idsession)
        {
            int id = (int)idsession;
            DateTime timenow = DateTime.Now;
            var AddDataOrderNew = new Order
            {
                Date = timenow,
                Email = orderinfo.Email,
                Product = _Context.SneakersProducts.FirstOrDefault(x => x.Id == id),
                Name = orderinfo.Name,
                LastName = orderinfo.LastName,
                Surname = orderinfo.Surname,
                NumberPostOffice = orderinfo.NumberPostOffice,
                UserId = idsession,
                Status = true
            };
            _Context.Add(AddDataOrderNew);
            _Context.SaveChanges();
        }

        public IQueryable<Order> MyOrders(int? idUser)
        {
            var User = _Context.Users.AsNoTracking().FirstOrDefault(x => x.Id == idUser);
            var myOrders = User.Orders.AsQueryable();
            return myOrders;
        }
    }
}
