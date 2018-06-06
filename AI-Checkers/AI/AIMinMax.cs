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
                CalculateChildTree(AI_TREEDEPTH, gameTree.AddChild(myPossibleMove), myPossibleMove, DeepCopy(board), isMaxing);
            }

            Move nextMove = GetBestMove(gameTree);
            return nextMove;
        }

        private void CalculateChildTree(int depth, Tree<Move> tree, Move myPossibleMove, Field[][] board, bool isMaxing)
        {
            try
            {
                board.MakeMove(myPossibleMove.X_Start, myPossibleMove.Y_Start, myPossibleMove.X_End, myPossibleMove.Y_End);
                tree.Score = ScoreBoard(board, isMaxing);
                if (depth > 0)
                {
                    var possibleMoves = GetPossibleMoves(board, true);
                    foreach (Move nextMove in possibleMoves)
                    {
                        CalculateChildTree(depth - 1, tree.AddChild(myPossibleMove), myPossibleMove, DeepCopy(board), !isMaxing);
                    }
                }
            }
            catch (Exception ex)
            {


            }
            //should i return sth or not
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
                result[i] = new Field[sourceBoard.Length];
                for (int j = 0; j < sourceBoard.Length; j++)
                {
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

        private Move GetBestMove(Tree<Move> gameTree)
        {
            Move finaleMove = new Move(-2, -2, -2, -2);
            var bestscore = Minimax(AI_TREEDEPTH, gameTree);
            var node = gameTree.Children.FirstOrDefault(x => x.Score == bestscore);
            finaleMove = node.Value;
            return finaleMove;
        }

        private float Minimax(int depth, Tree<Move> gameTree)
        {
            if (depth == 0)
            {
                return gameTree.Score;
            }
            float bestScore = -100000;
            foreach (var node in gameTree.Children)
            {
                var value = Minimax(depth - 1, node);
                bestScore = Math.Max(bestScore, value);
                gameTree.Score = bestScore;
                //close close - i'm losing the final move somewhere
            }
            return bestScore;
        }



    }
}
