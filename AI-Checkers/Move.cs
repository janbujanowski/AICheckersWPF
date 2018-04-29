using System;

namespace AI_Checkers
{
    public class Move
    {
        public readonly int X_Start, Y_Start, X_End, Y_End;

        public Move(int x_start, int y_start, int x_end, int y_end)
        {
            this.X_Start = x_start;
            this.X_End = x_end;
            this.Y_Start = y_start;
            this.Y_End = y_end;
        }

        public bool IsBasicMove
        {
            get
            {
                bool is_X_single = Math.Abs(X_End - X_Start) == 1;
                bool is_Y_single = Math.Abs(Y_End - Y_Start) == 1;
                return is_X_single && is_Y_single;
            }
        }

    }
}