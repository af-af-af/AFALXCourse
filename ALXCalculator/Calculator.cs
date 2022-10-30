namespace ALXCalculator
{
    public class Calculator
    {
        public void Run()
        {
            Console.WriteLine("Running calculator...");
            Console.Write("X number: ");
            var x = Double.Parse(Console.ReadLine());
            Console.Write("Y number: ");
            var y = Double.Parse(Console.ReadLine());
            Console.WriteLine($"{x} + {y} = {Add(x,y)}");
            Console.WriteLine($"{x} - {y} = {Substract(x,y)}");
            Console.WriteLine($"{x} * {y} = {Multiply(x,y)}");
            Console.WriteLine($"{x} / {y} = {Divide(x,y)}");
        }

        private double Add(double x, double y)
        {
            return x + y;
        }

        private double Substract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
