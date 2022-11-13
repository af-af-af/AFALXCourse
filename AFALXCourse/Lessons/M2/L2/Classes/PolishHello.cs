using AFALXCourse.Lessons.M2.L2.Interfaces;

namespace AFALXCourse.Lessons.M2.L2.Classes
{
    public class PolishHello : IHello
    {
        public void SayGoodMorning()
        {
            Console.WriteLine("Dzień dobry!");
        }

        public void SayGoodMorning(string name)
        {
            Console.WriteLine($"Dzień dobry {name}!");
        }

        public void SayHello()
        {
            Console.WriteLine("Cześć!");
        }

        public void SayHello(string name)
        {
            Console.WriteLine($"Cześć {name}!");
        }
    }
}
