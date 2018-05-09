using AI_Checkers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_Checkers.AI
{
    class AIRandom : IAI
    {
        // TODO create some random movement
        public Move GetNextMove(Field[][] board)
        {
            List<Point> checkersPositions = new List<Point>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j].Check != null && board[i][j].Check.isAI)
                    {
                        checkersPositions.Add(new Point(i, j));
                    }
                }
            }

            List<Move> possibleMoves = new List<Move>();

            foreach (var position in checkersPositions)
            {
                possibleMoves.AddRange(GetPossibleMoves((int)position.X, (int)position.Y, board));
            }

            return possibleMoves[new Random().Next(possibleMoves.Count - 1)];
        }

        private IEnumerable<Move> GetPossibleMoves(int x, int y, Field[][] board)
        {
            List<Move> possible = new List<Move>();
            List<Move> basicMoves = new List<Move>()
                {
                    new Move(x,y, x + 1, y + 1),
                    new Move(x,y, x - 1, y + 1),
                    new Move(x,y, x + 1, y - 1),
                    new Move(x,y, x - 1, y - 1)
                };

            possible.AddRange(basicMoves.Where(z => Rules.IsMovePossible(board, z)));
            List<Move> captureMoves = new List<Move>()
                {
                    new Move(x,y, x + 2, y + 2),
                    new Move(x,y, x - 2, y + 2),
                    new Move(x,y, x + 2, y - 2),
                    new Move(x,y, x - 2, y - 2)
                };
            possible.AddRange(captureMoves.Where(z => Rules.IsMovePossible(board, z)));
            return possible;
        }
    }
}
