using AFALXCourse.Lessons.L2.Enums;

namespace AFALXCourse.Lessons.L2
{
    public class ChessFigure
    {
        public ChessFigureType FigureType;
        public ChessColor FigureColor;
        public ChessFigure() {}
        public ChessFigure(ChessFigureType chessFigureType, ChessColor chessColor)
        {
            FigureType = chessFigureType;
            FigureColor = chessColor;
        }
    }
}
