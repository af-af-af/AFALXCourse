using CommonFunctionalities.Services.Interfaces;
using System.Text;

namespace CommonFunctionalities.Services
{
    public class ExpressionServiceDouble : IExpressionService
    {
        public string ProcessExpression(string expression)
        {
            if (!expression.EndsWith("="))
            {
                expression += "=";
            }
            var result = CalculateExpression(expression);
            return (result.ToString()).Replace(".", ",");
        }

        private double CalculateExpression(string expression)
        {
            List<double> numbers = new List<double>();
            List<char> operations = new List<char>();
            var numberBuilder = new StringBuilder();
            expression = expression.Replace(',', '.');
            var expressionArray = expression.ToCharArray();
            
            for(int i = 0; i < expressionArray.Length; i++)
            {
                if (Char.IsDigit(expressionArray[i]) || expressionArray[i]=='.')
                {
                    numberBuilder.Append(expressionArray[i]);
                }
                else
                {
                    var number = Convert.ToDouble(numberBuilder.ToString());
                    numberBuilder.Clear();
                    numbers.Add(number);
                    operations.Add(expressionArray[i]);
                }
            }
            var result = PerformOperations(numbers, operations);
            return result;
        }

        private double PerformOperations(List<double> numbers, List<char> operations)
        {
            var result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = PerformOperation(operations[i-1], result, numbers[i]);
            }

            return result;
        }

        private double PerformOperation(char operationChar, double x, double y)
        {
            switch (operationChar)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '*':
                    return x * y;
                case '/':
                    return x / y;
                default:
                    return x;
            }
        }
    }
}
