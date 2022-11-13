using AFALXCourse.Lessons.M2.L2.Classes;
using AFALXCourse.Lessons.M2.L2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Lessons.M2.L2
{
    public class L2Interfaces
    {
        public static void Run()
        {
            IHello helloService = new PolishHello();
            helloService.SayGoodMorning("Andrzej");
            helloService.SayGoodMorning();
            helloService.SayHello("Andrzej");
            helloService.SayHello();

            helloService = new Hello();
            helloService.SayGoodMorning("Andrzej");
            helloService.SayGoodMorning();
            helloService.SayHello("Andrzej");
            helloService.SayHello();
        }
    }
}
