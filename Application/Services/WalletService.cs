using Application.Interface.RepositoryInterface;
using Application.Interface.ServiceInterface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepo;

        public WalletService(IWalletRepository walletRepo)
        {
            _walletRepo = walletRepo;
        }

        public async Task<decimal> GetBalanceAsync(int userId)
        {
            var wallet = await _walletRepo.GetWalletByUserIdAsync(userId);
            return wallet?.Balance ?? 0;
        }

        public async Task<bool> CreditAsync(int userId, decimal amount, string description)
        {
            var wallet = await _walletRepo.GetWalletByUserIdAsync(userId);
            if (wallet == null) wallet = await _walletRepo.CreateWalletAsync(userId);

            wallet.Balance += amount;
            wallet.UpdatedAt = DateTime.UtcNow;

            var transaction = new WalletTransaction
            {
                WalletId = wallet.Id,
                Amount = amount,
                Type = "Credit",
                Description = description,
                CreatedAt = DateTime.UtcNow
            };

            return await _walletRepo.UpdateWalletAsync(wallet, transaction);
        }

        public async Task<bool> DebitAsync(int userId, decimal amount, string description)
        {
            var wallet = await _walletRepo.GetWalletByUserIdAsync(userId);
            if (wallet == null || wallet.Balance < amount)
                return false; // insufficient funds

            wallet.Balance -= amount;
            wallet.UpdatedAt = DateTime.UtcNow;

            var transaction = new WalletTransaction
            {
                WalletId = wallet.Id,
                Amount = amount,
                Type = "Debit",
                Description = description,
                CreatedAt = DateTime.UtcNow
            };

            return await _walletRepo.UpdateWalletAsync(wallet, transaction);
        }

        public async Task<List<WalletTransaction>> GetTransactionsAsync(int userId)
        {
            return await _walletRepo.GetTransactionsByUserIdAsync(userId);
        }
    }
}
