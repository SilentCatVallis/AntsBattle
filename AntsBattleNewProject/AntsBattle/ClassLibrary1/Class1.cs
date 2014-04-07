﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntsBattle;
using System.Drawing;

namespace ClassLibrary1
{
    public class Class1 : IAntAI
    {
        private int a = 0;
        public Direction GetDirection(Point from, AIWorld world)
        {
            a++;
            var obj = world.GetObjectInCell(new Point(2, 2));
            return a % 2 == 0 ? Direction.Up : Direction.Down;
        }

        public string GetPlayerName()
        {
            return "SashaWinForever";
        }
    }
}