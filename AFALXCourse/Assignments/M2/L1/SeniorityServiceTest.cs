using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Assignments.M2.L1
{
    public static class SeniorityServiceTest
    {
        public static void Run()
        {
            var seniorityService = new SeniorityService();
            PresentEmployees(seniorityService.JuniorEmployees);
            //
            Console.WriteLine("Juniors: ");
            //
            Console.WriteLine("Mids: ");
            //
            Console.WriteLine("Seniors: ");
            //
        }

        public static void PresentEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.Name}");
            }
        }
    }
}
