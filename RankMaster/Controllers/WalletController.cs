using Application.Dto;
using Application.Interface.ServiceInterface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PscExamMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public WalletController(IWalletService walletService, IMapper mapper, IConfiguration config)
        {
            _walletService = walletService;
            _mapper = mapper;
            _config = config;
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID not found in token.");
            return int.Parse(userIdClaim.Value);
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance()
        {
            int userId = GetUserIdFromToken();
            var balance = await _walletService.GetBalanceAsync(userId);
            return Ok(new { balance });
        }

        [HttpPost("credit")]
        public async Task<IActionResult> Credit([FromBody] WalletTransactionDto dto)
        {
            int userId = GetUserIdFromToken();
            var result = await _walletService.CreditAsync(userId, dto.Amount, dto.Description);
            return result ? Ok("Credited") : BadRequest("Failed");
        }

        [HttpPost("debit")]
        public async Task<IActionResult> Debit([FromBody] WalletTransactionDto dto)
        {
            int userId = GetUserIdFromToken();
            var result = await _walletService.DebitAsync(userId, dto.Amount, dto.Description);
            return result ? Ok("Debited") : BadRequest("Insufficient Balance");
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            int userId = GetUserIdFromToken();
            var transactions = await _walletService.GetTransactionsAsync(userId);
            var result = _mapper.Map<List<WalletTransactionDto>>(transactions);
            return Ok(result);
        }

        [HttpPost("razorpay/create-order")]
        public IActionResult CreateOrder([FromBody] WalletTransactionDto dto)
        {
            RazorpayClient client = new RazorpayClient(_config["Razorpay:Key"], _config["Razorpay:Secret"]);

            Dictionary<string, object> options = new Dictionary<string, object>
            {
                { "amount", dto.Amount * 100 }, // in paise
                { "currency", "INR" },
                { "receipt", Guid.NewGuid().ToString() },
                { "payment_capture", 1 }
            };

            Order order = client.Order.Create(options);

            return Ok(new
            {
                orderId = order["id"].ToString(),
                key = _config["Razorpay:Key"],
                amount = order["amount"],
                currency = order["currency"]
            });
        }

        [HttpPost("razorpay/verify-payment")]
        public async Task<IActionResult> VerifyPayment([FromBody] RazorpayVerificationDto dto)
        {
            int userId = GetUserIdFromToken();

            string secret = _config["Razorpay:Secret"];
            string payload = dto.OrderId + "|" + dto.PaymentId;

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            string generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();

            if (generatedSignature != dto.Signature.ToLower())
                return BadRequest("Invalid Razorpay signature");

            var success = await _walletService.CreditAsync(userId, dto.Amount, dto.Description ?? "Razorpay Payment");
            return success ? Ok("Wallet credited.") : BadRequest("Credit failed.");
        }
    }
}
