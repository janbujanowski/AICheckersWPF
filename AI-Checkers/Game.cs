using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers
{
    public class Game : INotifyPropertyChanged
    {
        public Field[][] board;

        private int boardSize = 8;
        private string nameValue;
        private int[][] myarr;
        
        public Game()
        {
            InitBoard();
            this.nameValue = "lol";
        }

        private void InitBoard()
        {
            this.board = new Field[boardSize][];
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Field[boardSize];
            }
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i][j] = new Field();
                }
            }
        }

        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        public Field[][] Board
        {
            get { return board; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
