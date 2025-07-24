using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class WalletTransactionResponseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // Credit or Debit
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
