namespace WebApi.Models
{
    public class Paycheck
    {
        public Guid Id { get; set; }
        public string PaycheckNumber { get; set; }
        public decimal PaymentGross { get; set; }
        public decimal PaymentNet { get; set; }
        public bool IsPaid { get; set; }
    }
}
