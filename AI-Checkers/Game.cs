using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers
{
    public class Game : INotifyPropertyChanged
    {
        private Field[][] board;
        private int boardSize = 8;
        private string nameValue;

        public Game()
        {
            InitBoard();
            this.nameValue = "AI-Checkers!";
        }

        private void InitBoard()
        {
            this.board = new Field[boardSize][];

            for (int i = 0; i < boardSize; i++)
            {
                board[i] = new Field[boardSize];
                if (i % 2 == 0)
                {
                    board[i][0] = new Field(FieldStatus.Player2, true);
                    board[i][2] = new Field(FieldStatus.Player2, false);
                    board[i][6] = new Field(FieldStatus.Player1, false);

                    board[i][1] = new Field(FieldStatus.Empty, false);
                    board[i][3] = new Field(FieldStatus.Empty, false);
                    board[i][4] = new Field(FieldStatus.Empty, false);
                    board[i][5] = new Field(FieldStatus.Empty, false);
                    board[i][7] = new Field(FieldStatus.Empty, false);

                }
                else
                {
                    board[i][1] = new Field(FieldStatus.Player2, false);
                    board[i][5] = new Field(FieldStatus.Player1, false);
                    board[i][7] = new Field(FieldStatus.Player1, true);

                    board[i][0] = new Field(FieldStatus.Empty, false);
                    board[i][2] = new Field(FieldStatus.Empty, false);
                    board[i][3] = new Field(FieldStatus.Empty, false);
                    board[i][4] = new Field(FieldStatus.Empty, false);
                    board[i][6] = new Field(FieldStatus.Empty, false);
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
            if (Rules.IsMovePossible(board,x_start,y_start,x_end,y_end))
            {
                var movingChecker = board[x_start][y_start].Status;
                board[x_end][y_end].Status = movingChecker;
                board[x_start][y_start].Status = FieldStatus.Empty;
            }
        }

        public Move[] GetPossibleMoves(int posx, int posy)
        {
            return Rules.GetPossibleMoves(board, posx, posy);
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
