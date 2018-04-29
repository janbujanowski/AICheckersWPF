using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers
{
    public static class Rules
    {
        public static Move[] GetPossibleMoves(Field[][] board, int posx, int posy)
        {
            throw new NotImplementedException();
        }

        public static bool IsMovePossible(Field[][] board, Move move)
        {
            Field start = board[move.X_Start][move.Y_Start];
            Field destination = board[move.X_End][move.Y_End];
            bool isQueenChecker = start.Status == FieldStatus.Player1Queen || start.Status == FieldStatus.Player2Queen;
            if (move.IsBasicMove)
            {
                if (destination.Status == FieldStatus.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //to do Rules for skipping// capturing
                throw new NotImplementedException();
            }
        }


        public static bool IsMovePossible(Field[][] board, int x_start, int y_start, int x_end, int posy2)
        {
            Move move = new Move(x_start, y_start, x_end, posy2);
            return IsMovePossible(board, move);
        }
    }
}
