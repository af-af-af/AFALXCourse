using AFALXCourse.Lessons.M1.L2.Enums;

namespace AFALXCourse.Lessons.M2.L2.Classes.Inheritance
{
    public class Knight : ChessPiece
    {
        public Knight() : base()
        {
            Type = ChessFigureType.KNIGHT;
        }

        //override
        public void Move()
        {
            Console.WriteLine("The Knight is moving...");
        }
    }
}
