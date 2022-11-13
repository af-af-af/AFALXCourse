using AFALXCourse.Lessons.M1.L2.Enums;
using AFALXCourse.Lessons.M2.L2.Classes.Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFALXCourse.Lessons.M2.L2
{
    public class L2Inheritance
    {
        public static void Run()
        {
            ChessPiece chessPiece = new King();
            chessPiece.XPosition = 1;
            chessPiece.YPosition = 1;
            chessPiece.Move();
            chessPiece.Present();
            ConfirmLiveness(chessPiece);

            Queen queen = new Queen();
            queen.Move();
            queen.XPosition = 1;
            queen.YPosition = 1;
            queen.Color = ChessColor.WHITE;
            queen.Present();
            ConfirmLiveness(queen);

            Knight knight = new Knight();
            knight.Move();
            knight.XPosition = 1;
            knight.YPosition = 1;
            knight.Color = ChessColor.WHITE;
            knight.Present();
            ConfirmLiveness(knight);

            Bishop bishop = new Bishop();
            bishop.Move();
            bishop.XPosition = 1;
            bishop.YPosition = 1;
            bishop.Color = ChessColor.WHITE;
            bishop.Present();
            ConfirmLiveness(bishop);
        }

        private static void ConfirmLiveness(ChessPiece queen)
        {
            if (queen.IsAlive)
            {
                Console.WriteLine("The piece is alive!");
            }
            else
            {
                Console.WriteLine("The piece is dead...");
            }
        }
    }
}
