using AFALXCourse.Lessons.M1.L2.Enums;

namespace AFALXCourse.Lessons.M2.L2.Classes.Inheritance
{
    public class Bishop : ChessPiece
    {
        public Bishop() : base()
        {
            Type = ChessFigureType.BISHOP;
        }

        //override
        public void Move()
        {
            Console.WriteLine("The Bishop is moving...");
        }
    }
}
