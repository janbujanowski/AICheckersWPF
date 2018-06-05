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

    }
}
