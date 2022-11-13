using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Lessons.M2.L2.Classes
{
    public class Computer
    {
        private string _brand;

        public string Brand 
        {
            get 
            {
                Console.WriteLine("Getting computer brand.");
                return _brand; 
            }
            set 
            { 
                Console.WriteLine($"Setting computer brand as {value}");
                _brand = value; 
            }
        }

        public string Name { get; set; }

        private double? _processorFrequency;

        public double? ProcessorFrequency
        {
            get
            {
                Console.WriteLine("Getting processor clock frequency [GHz]...");
                return _processorFrequency;
            }
            set
            {
                if (value > 0 && value < 4)
                {
                    Console.WriteLine($"Setting computer's processor clock frequency as {value} [GHz].");
                    _processorFrequency = value;
                }
                else
                {
                    Console.WriteLine("Invalid processor frequency value!");
                }
            }
        }

        public int NumberOfCores { get; set; }
        public string Model;

        private int StorageSpace { get; }
        public readonly string GraphicalCardModel;
    }
}
