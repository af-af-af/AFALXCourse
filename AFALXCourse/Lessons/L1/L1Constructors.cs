using AFALXCourse.Lessons.L1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Lessons
{
    public class L1Constructors
    {
        public static void Run()
        {
            var spider = new Spider();
            spider.Color = "black";
            spider.Species = "Black Widow";
            spider.IsVenomous = true;
            spider.Sex = "female";

            var redSpider = new Spider("red", "Tarantula", false, "male");

            var blueSpider = new Spider("blue", "Goliath");

            var yellowSpider = new Spider("yellow", false);
        }
    }
}
