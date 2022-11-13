using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Assignments.M2.L1
{
    public class SeniorityService
    {
        public List<Employee> JuniorEmployees;
        public List<Employee> MidEmployees;
        public List<Employee> SeniorEmployees;

        public SeniorityService()
        {
            JuniorEmployees = new List<Employee>();
            MidEmployees = new List<Employee>();
            SeniorEmployees = new List<Employee>();
        }

        public void ClassifySeniorityBySalary(Employee employee)
        {
            //... 
            JuniorEmployees.Add(employee);
        }

        public void ClassifySeniorityByExperience(Employee employee)
        {
            //... 
            JuniorEmployees.Add(employee);
            MidEmployees.Remove(employee);
            SeniorEmployees.Clear();
        }
    }
}
