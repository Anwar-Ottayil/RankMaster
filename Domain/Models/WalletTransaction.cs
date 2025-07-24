using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class WalletTransaction
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // Credit or Debit
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
