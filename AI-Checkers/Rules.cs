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

        public static bool isMovePossible(Field[] board, Move move)
        {
            throw new NotImplementedException();
        }

        public static bool isMovePossible(Field[] board, int posx, int posy, int posx2, int posy2)
        {
            Move move = new Move(posx, posy, posx2, posy2);
            return isMovePossible(board, move);
        }
    }
}
