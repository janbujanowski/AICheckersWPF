﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Checkers
{
    interface IAI
    {
        Move GetNextMove(Field[][] board);
    }
}