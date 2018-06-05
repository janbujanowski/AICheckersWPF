using AI_Checkers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers.AI
{
    class AIMinMax : IAI
    {
        const int AI_TREEDEPTH = 5;

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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j].Check.isAI)
                    {
                        var possibleMoves = GetPossibleMoves(board, i, j);
                        foreach (Move myPossibleMove in possibleMoves)
                        {

                            // CalculateChildMoves(0, gameTree.AddChild(myPossibleMove), myPossibleMove, DeepCopy(Board));

                            //gameTree.AddChildren(Utils.GetOpenSquares(Board, new Point(j, i)));
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("AI: Scoring Game Tree...");

            Move nextMove = ScoreTreeMoves(gameTree);

            return nextMove;
        }

        private Field[][] DeepCopy(Field[][] sourceBoard)
        {
            Field[][] result = new Field[8][];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result[i] = new Field[8];
                    result[i][j] = new Field(sourceBoard[i][j].Check, sourceBoard[i][j].IsQueenField);
                }
            }

            return result;
        }

        private Move ScoreTreeMoves(Tree<Move> gameTree)
        {
            throw new NotImplementedException();
        }

        private float ScoreBoard(Field[][] board, bool isAiMax)
        {
            float score = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
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

        private List<Move> GetPossibleMoves(Field[][] board, int i, int j)
        {
            throw new NotImplementedException();
        }

    }
}
