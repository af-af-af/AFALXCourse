using CourseFormApp.Exceptions;

namespace CourseFormApp
{
    public class ThrowExceptionExample
    {
        public void Run()
        {
            MessageBox.Show("Throwing exception");
            throw new OurOwnException("Do not click that button!");
        }
    }
}
