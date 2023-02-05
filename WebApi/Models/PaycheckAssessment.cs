using System.Security.Principal;

namespace WebApi.Models
{
    public class PaycheckAssessment
    {
        public string PaycheckNumber { get; set; }
        public decimal PaymentGross { get; set; }
    }
}
