using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFunctionalities.Services.Interfaces
{
    public interface ITaxService
    {
        double CalculateTax(double income);
    }
}
