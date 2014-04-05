using System;
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
        public Direction GetDirection(Point from, AIWorld world)
        {
            var obj = world.GetObjectInCell(new Point(2, 2));
            return obj == AntsBattle.Object.YourAnt ? Direction.Left : Direction.Down;
        }
    }
}
