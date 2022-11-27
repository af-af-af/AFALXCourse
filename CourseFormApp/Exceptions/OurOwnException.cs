using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseFormApp.Exceptions
{
    public class OurOwnException : Exception
    {
        public OurOwnException()
        {
        }

        public OurOwnException(string? message) : base(message)
        {
        }

        public OurOwnException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
