namespace Application.Dto
{
    public class RazorpayVerificationDto
    {
        public string OrderId { get; set; }
        public string PaymentId { get; set; }
        public string Signature { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
