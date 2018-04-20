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
        public Field[][] board;
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
                }
                else
                {
                    board[i][1] = new Field(FieldStatus.Player2, false);
                    board[i][5] = new Field(FieldStatus.Player1, false);
                    board[i][7] = new Field(FieldStatus.Player1, true);
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
