using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_Checkers
{
    public static class Rules
    {
        public static Move[] GetPossibleMoves(Field[][] board, int x_start, int y_start)
        {
            throw new NotImplementedException();
        }

        public static bool IsMovePossible(Field[][] board, Move move, List<Point> checkersToRemove = default(List<Point>))
        {
            Field destination = board[move.X_End][move.Y_End];
            if (destination.Status != FieldStatus.Empty)
            {
                throw new InvalidOperationException();
            }

            Field start = board[move.X_Start][move.Y_Start];
            bool isQueenChecker = start.Status == FieldStatus.Player1Queen || start.Status == FieldStatus.Player2Queen;
            if (move.IsBasicMove)
            {
                return true;
            }
            else
            {
                if (Math.Abs(move.X_End - move.X_Start) == 2 && Math.Abs(move.Y_End - move.Y_Start) == 2)
                {
                    var x_FieldBetween = move.X_Start + (move.X_End - move.X_Start) / 2;
                    var y_FieldBetween = move.Y_Start + (move.Y_End - move.Y_Start) / 2;
                    Field between = board[x_FieldBetween][y_FieldBetween];
                    if (start.Status == FieldStatus.Player1 || start.Status == FieldStatus.Player1Queen)
                    {
                        if (between.Status == FieldStatus.Player2 || between.Status == FieldStatus.Player2Queen)
                        {
                            checkersToRemove.Add(new Point(x_FieldBetween, y_FieldBetween));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (start.Status == FieldStatus.Player2 || start.Status == FieldStatus.Player2Queen)
                    {
                        if (between.Status == FieldStatus.Player1 || between.Status == FieldStatus.Player1Queen)
                        {
                            checkersToRemove.Add(new Point(x_FieldBetween, y_FieldBetween));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //its recurring move, or queen
                }
                throw new NotImplementedException();
            }
        }


        public static bool IsMovePossible(Field[][] board, int x_start, int y_start, int x_end, int y_end, List<Point> checkersToRemove = default(List<Point>))
        {
            Move move = new Move(x_start, y_start, x_end, y_end);
            return IsMovePossible(board, move, checkersToRemove);
        }
    }
}
