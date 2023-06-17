using SeakerSop.Models;

namespace SeakerSop.Repository
{
    public interface IRepository
    {
        void AddData(User user);
        IQueryable<User> ReadDataUser();
        IQueryable<SneakersProduct> ReadDataSneakersMan();
        void AddCartProduct(string name, int size, string country, string color, int price,DateTime timeadd,string pictures);
        IQueryable<Cart> ReadDataCart();
        void DeleteProductCart(int id);
        void AddOrderInfo(OrderNotMap orderinfo,int? idsession);
        IQueryable<Order> MyOrders( int? idUser);
    }
    public interface IRepositoryPayBase
    {
        List<RequisitesUser> ReadData();
        void UptadeBalanceUser(double newvaluebalance , long cardNumber);
    }
}
