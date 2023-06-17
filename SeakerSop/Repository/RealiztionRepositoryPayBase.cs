using Microsoft.EntityFrameworkCore;
using SeakerSop.Models;

namespace SeakerSop.Repository
{
    public class RealiztionRepositoryPayBase : IRepositoryPayBase
    {
        private readonly DbPayContext _PayContext;
        public RealiztionRepositoryPayBase(DbPayContext paycontext)
        {
            _PayContext = paycontext;
        }
        public List<RequisitesUser> ReadData()
        {
            var DataPay = _PayContext.RequisitesUsers.AsNoTracking().ToList();
            return DataPay;
        }

        public void UptadeBalanceUser(double newValueBalance, long cardNumber)
        {
            var balance = _PayContext.RequisitesUsers.Single(x => x.CardNumber == cardNumber);
            balance.Balance = newValueBalance;
            _PayContext.SaveChanges();
        }
    }
}
