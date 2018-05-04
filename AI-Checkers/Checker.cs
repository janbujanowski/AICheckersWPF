using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AI_Checkers
{
    public class Checker
    {
        public bool isQueen;
        public readonly bool isAI;

        public Checker(bool isQueen, bool isAI)
        {
            this.isQueen = isQueen;
            this.isAI = isAI;
        }

        public Brush Color
        {
            get
            {
                if (isAI && !isQueen)
                {
                    return Brushes.Black;
                }
                if (isAI && isQueen)
                {
                    return Brushes.Gray;
                }
                if (!isAI && !isQueen)
                {
                    return Brushes.Pink;
                }
                if (!isAI && isQueen)
                {
                    return Brushes.Red;
                }
                return Brushes.Transparent;
            }
        }

    }
}
