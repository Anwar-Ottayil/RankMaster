using Application.Interface.RepositoryInterface;
using Domain.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> GetWalletByUserIdAsync(int userId)
        {
            return await _context.Wallets
                .Include(w => w.Transactions)
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task<Wallet> CreateWalletAsync(int userId)
        {
            var wallet = new Wallet
            {
                UserId = userId,
                Balance = 0,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();

            return wallet;
        }

        public async Task<bool> UpdateWalletAsync(Wallet wallet, WalletTransaction transaction)
        {
            _context.Wallets.Update(wallet);
            _context.WalletTransactions.Add(transaction);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<WalletTransaction>> GetTransactionsByUserIdAsync(int userId)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null) return new List<WalletTransaction>();

            return await _context.WalletTransactions
                .Where(t => t.WalletId == wallet.Id)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}
