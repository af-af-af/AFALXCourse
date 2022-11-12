namespace AFALXCourse.Lessons.M2.L1
{
    public class L1Loops
    {
        public static void RunForeach()
        {
            List<string> names = new List<string>();
            names.Add("Adrian");
            names.Add("Mateusz");
            names.Add("Monika");
            names.Add("Magda");
            names.Add("Andrzej");

            foreach (string name in names)
            {
                Console.WriteLine(name.ToLower() + " kursant.");
                Console.WriteLine(name);
            }
        }

        public static void RunFor()
        {
            int[] numbers = new int[12] { 1, 2, 4, 5, 6, 7, 3, 4, 5, 66, 5, 4 };

            for(int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i += 2)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            for (int i = numbers.Length-1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                numbers[i] = numbers[i] % 2;
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }

        public static void RunWhile()
        {
            Console.Write("Write a character: ");
            var c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (c != 'n')
            {
                Console.WriteLine("still in the loop!");
                
                Console.WriteLine();
            }
            Console.WriteLine("Outside the loop.");

/*            string numberFromKeyboard = "0";
            while (Int32.Parse(numberFromKeyboard) < 100000)
            {
                Console.WriteLine("still in the loop!");
                Console.Write("Write a number: ");
                numberFromKeyboard = Console.ReadLine();
                Console.WriteLine();
            }
            Console.WriteLine("Outside the loop.");*/
        }

        public static void RunDoWhile()
        {
            Console.Write("Write a character: ");
            var c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            do
            {
                Console.WriteLine("still in the loop!");
                Console.Write("Write a character: ");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (c != 'n');

            Console.WriteLine("Outside the loop.");
        }

        public static void RunWhile2()
        {
            int[] numbers = new int[12] { 1, 2, 4, 5, 6, 7, 3, 4, 5, 66, 5, 4 };

            int iterator = 0;

            while (true)
            {
                Console.Write(numbers[iterator]);
                iterator++;
            }
            Console.WriteLine();
        }

        public static void RunWhileInfinite()
        {
            while (true)
            {
                var rnd = new Random();
                var number = rnd.Next(0, 9);
                var number1 = rnd.Next(0, 9);
                Console.Write(number1.ToString() + number.ToString());
            }
            Console.WriteLine();
        }
    }
}
