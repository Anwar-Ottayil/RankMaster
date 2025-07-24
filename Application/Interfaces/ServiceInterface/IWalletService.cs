using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.ServiceInterface
{
    public interface IWalletService
    {
        Task<decimal> GetBalanceAsync(int userId);
        Task<bool> CreditAsync(int userId, decimal amount, string description);
        Task<bool> DebitAsync(int userId, decimal amount, string description);
        Task<List<WalletTransaction>> GetTransactionsAsync(int userId);
    }
}
