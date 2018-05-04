using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace AI_Checkers
{
    public class Game : INotifyPropertyChanged
    {
        private Field[][] board;
        private int boardSize = 8;
        private string nameValue;

        private StringBuilder gameInfo;

        public Game()
        {
            InitBoard();
            this.nameValue = "AI-Checkers!";
            gameInfo = new StringBuilder();
            AddGameLog("Game initialized");
        }

        private void InitBoard()
        {
            this.board = new Field[boardSize][];
            bool isAI = true;
            bool isQueen = true;

            for (int i = 0; i < boardSize; i++)
            {
                board[i] = new Field[boardSize];
                if (i % 2 != 0)
                {
                    board[i][0] = new Field(new Checker(!isQueen, isAI), isQueen);
                    board[i][2] = new Field(new Checker(!isQueen, isAI), !isQueen);
                    board[i][6] = new Field(new Checker(!isQueen, !isAI), !isQueen);

                    board[i][1] = new Field(null, !isQueen);
                    board[i][3] = new Field(null, !isQueen);
                    board[i][4] = new Field(null, !isQueen);
                    board[i][5] = new Field(null, !isQueen);
                    board[i][7] = new Field(null, !isQueen);
                }
                else
                {
                    board[i][1] = new Field(new Checker(!isQueen, isAI), !isQueen);
                    board[i][5] = new Field(new Checker(!isQueen, !isAI), !isQueen);
                    board[i][7] = new Field(new Checker(!isQueen, !isAI), isQueen);

                    board[i][0] = new Field(null, !isQueen);
                    board[i][2] = new Field(null, !isQueen);
                    board[i][3] = new Field(null, !isQueen);
                    board[i][4] = new Field(null, !isQueen);
                    board[i][6] = new Field(null, !isQueen);
                }
            }
        }

        public string Name
        {
            get { return nameValue; }
            set
            {
                nameValue = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string GameInfo
        {
            get
            {
                return gameInfo.ToString();
            }
        }

        private void AddGameLog(string message)
        {
            gameInfo.AppendLine(message);
            NotifyPropertyChanged("GameInfo");
        }

        public Field[][] Board
        {
            get { return board; }
        }

        public void MakeMove(Move move)
        {
            MakeMove(move.X_Start, move.Y_Start, move.X_End, move.Y_End);
        }

        public void MakeMove(int x_start, int y_start, int x_end, int y_end)
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
            }
            else
            {
                AddGameLog($"Move {x_start},{y_start} -> {x_end},{y_end} not possible");
            }
        }

        public Move[] GetPossibleMoves(int x_start, int y_start)
        {
            return Rules.GetPossibleMoves(board, x_start, y_start);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
