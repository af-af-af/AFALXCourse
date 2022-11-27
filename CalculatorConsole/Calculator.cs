using CommonFunctionalities.Services;
using CommonFunctionalities.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsole
{
    public class Calculator
    {
        private IExpressionService Service;

        public Calculator()
        {
            Service = new ExpressionServiceDecimal();
        }

        public void Run()
        {
            Console.WriteLine("Enter an expression: ");
            var expression = Console.ReadLine();
            expression = RefactorExpression(expression);
            var result = Service.ProcessExpression(expression);
            Console.WriteLine($"Result: {result}");
        }

        private string RefactorExpression(string expression)
        {
            expression = expression.Trim();
            expression = expression.Replace(" ", String.Empty);
            return expression;
        }
    }
}
