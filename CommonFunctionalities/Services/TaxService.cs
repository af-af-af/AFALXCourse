using CommonFunctionalities.Services.Interfaces;

namespace CommonFunctionalities.Services
{
    public class TaxService : ITaxService
    {
        private const double VatPercentage = 0.23;
        private const double GovernmentPercentage = 0.17;

        public double CalculateTax(double income)
        {
            var vatTax = CalculateVat(income);
            var governmentTax = CalculateGovernmentTax(income, vatTax);
            return vatTax + governmentTax;
        }

        public decimal CalculateTaxDecimal(decimal income)
        {
            var vatTax = CalculateVatDecimal(income);
            var governmentTax = CalculateGovernmentTaxDecimal(income, vatTax);
            return vatTax + governmentTax;
        }

        private double CalculateGovernmentTax(double income, double vatTax)
        {
            return (income - vatTax) * GovernmentPercentage;
        }

        private double CalculateVat(double income)
        {
            return income * VatPercentage;
        }

        private decimal CalculateGovernmentTaxDecimal(decimal income, decimal vatTax)
        {
            return (income - vatTax) * Convert.ToDecimal(GovernmentPercentage);
        }

        private decimal CalculateVatDecimal(decimal income)
        {
            return income * Convert.ToDecimal(VatPercentage);
        }
    }
}
