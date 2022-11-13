using AFALXCourse.Lessons.M2.L2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Lessons.M2.L2.Interfaces
{
    public interface IInvoiceGenerator
    {
        Invoice GenerateInvoice();
    }
}
