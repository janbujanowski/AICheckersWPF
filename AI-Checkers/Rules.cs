using System;
using System.Collections.Generic;
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
            if (destination.Check != null)
            {
                return false;
            }

            Field start = board[move.X_Start][move.Y_Start];
            bool isQueenChecker = start.Check.isQueen;
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
                    if (!start.Check.isAI)
                    {
                        if (between.Check.isAI)
                        {
                            checkersToRemove.Add(new Point(x_FieldBetween, y_FieldBetween));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (start.Check.isAI)
                    {
                        if (!between.Check.isAI)
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
