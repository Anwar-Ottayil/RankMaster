using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.RepositoryInterface
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserIdAsync(int userId);
        Task<Wallet> CreateWalletAsync(int userId);
        Task<bool> UpdateWalletAsync(Wallet wallet, WalletTransaction transaction);
        Task<List<WalletTransaction>> GetTransactionsByUserIdAsync(int userId);
    }
}
