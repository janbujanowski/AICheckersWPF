using AI_Checkers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_Checkers.AI
{
    class AIMinMax : IAI
    {
        const int AI_TREEDEPTH = 3;

        const int WEIGHT_SINGLECHECKER = 2;
        const int WEIGHT_QUEEN = 6;
        //int WEIGHT_CAPTUREDOUBLE = 5;
        //int WEIGHT_CAPTUREMULTI = 10;

        ////Defensive
        //int WEIGHT_ATRISK = 3;
        //int WEIGHT_KINGATRISK = 4;

        ////Strategic
        //int WEIGHT_MAKEKING = 1;
        Tree<Move> gameTree;

        public Move GetNextMove(Field[][] board)
        {
            Console.WriteLine();
            Console.WriteLine("AI: Building Game Tree...");

            gameTree = new Tree<Move>(new Move(-1, -1, -1, -1));
            var possibleMoves = GetPossibleMoves(board, true);
            foreach (Move myPossibleMove in possibleMoves)
            {
                var isMaxing = true;
                
                CalculateChildTree(AI_TREEDEPTH, gameTree.AddChild(myPossibleMove), myPossibleMove, DeepCopy(board));

                //gameTree.AddChildren(Utils.GetOpenSquares(Board, new Point(j, i)));
            }

            Move nextMove = ScoreTreeMoves(gameTree);
            return nextMove;
        }

        private void CalculateChildTree(int aI_TREEDEPTH, Tree<Move> tree, Move myPossibleMove, Field[][] board)
        {
            board.MakeMove(myPossibleMove.X_Start, myPossibleMove.Y_Start, myPossibleMove.X_End, myPossibleMove.Y_End);
        }

        private List<Move> GetPossibleMoves(Field[][] board, bool getAiMoves)
        {
            var possibleMoves = new List<Move>();
            var openSquares = GetOpenSquares(board);
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    var check = board[i][j].Check;
                    if (check != null && check.isAI == getAiMoves)
                    {
                        foreach (var square in openSquares)
                        {
                            var tryMove = new Move(i, j, (int)square.X, (int)square.Y);
                            if (Rules.IsMovePossible(board, tryMove))
                            {
                                possibleMoves.Add(tryMove);
                            }
                        }
                    }
                }
            }
            return possibleMoves;
        }
        private List<Point> GetOpenSquares(Field[][] board)
        {
            var openSquares = new List<Point>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j].Check == null)
                    {
                        openSquares.Add(new Point(i, j));
                    }
                }
            }
            return openSquares;
        }

        private Field[][] DeepCopy(Field[][] sourceBoard)
        {
            Field[][] result = new Field[sourceBoard.Length][];

            for (int i = 0; i < sourceBoard.Length; i++)
            {
                for (int j = 0; j < sourceBoard.Length; j++)
                {
                    result[i] = new Field[sourceBoard.Length];
                    result[i][j] = new Field(sourceBoard[i][j].Check, sourceBoard[i][j].IsQueenField);
                }
            }

            return result;
        }
        private float ScoreBoard(Field[][] board, bool isAiMax)
        {
            float score = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    var checker = board[i][j].Check;
                    if (checker != null)
                    {
                        if (checker.isAI)
                        {
                            score += WEIGHT_SINGLECHECKER;
                        }
                        if (checker.isQueen)
                        {
                            score += WEIGHT_QUEEN;
                        }
                    }
                }
            }
            if (!isAiMax)
            {
                score = -1 * score;
            }
            return score;
        }

        private Move ScoreTreeMoves(Tree<Move> gameTree)
        {
            throw new NotImplementedException();
        }



    }
}
