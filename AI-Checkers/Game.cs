using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers
{
    public class Game
    {
        public Field[,] Board;

        public Game()
        {
            this.Board = new Field[8, 8];
        }
    }
}
