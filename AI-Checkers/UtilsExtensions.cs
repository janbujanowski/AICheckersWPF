using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_Checkers
{
    public static class UtilsExtensions
    {
        public static bool MakeMove(this Field[][] board, Move move)
        {
            return board.MakeMove(move.X_Start, move.Y_Start, move.X_End, move.Y_End);
        }
        public static bool MakeMove(this Field[][] board,int x_start, int y_start, int x_end, int y_end)
        {
            List<Point> checkersToRemove = new List<Point>();
            if (Rules.IsMovePossible(board, x_start, y_start, x_end, y_end, checkersToRemove))
            {
                var movingChecker = board[x_start][y_start].Check;
                if (board[x_end][y_end].IsQueenField)
                {
                    if (!movingChecker.isQueen)
                    {
                        movingChecker.isQueen = true;
                    }
                }
                board[x_end][y_end].Check = movingChecker;
                board[x_start][y_start].Check = null;
                foreach (var field in checkersToRemove)
                {
                    board[(int)field.X][(int)field.Y].Check = null;
                }
                return true;
            }
            else
            {
                //AddGameLog($"Move {x_start},{y_start} -> {x_end},{y_end} not possible");
            }
            return false;
        }
        public static Field[][] DeepCopy(this Field[][] sourceBoard)
        {
            Field[][] result = new Field[sourceBoard.Length][];

            for (int i = 0; i < sourceBoard.Length; i++)
            {
                result[i] = new Field[sourceBoard.Length];
                for (int j = 0; j < sourceBoard.Length; j++)
                {
                    Checker check = null;
                    if (sourceBoard[i][j].Check != null)
                    {
                        check = new Checker(sourceBoard[i][j].Check.isQueen, sourceBoard[i][j].Check.isAI);
                    }
                    result[i][j] = new Field(check, sourceBoard[i][j].IsQueenField);
                }
            }

            return result;
        }

    }
}
