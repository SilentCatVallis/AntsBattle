using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    public interface IAntAI
    {
        Direction GetDirection(Point from, AIWorld world);
        string GetPlayerName();
    }

    public enum Direction
    {
        None, Up, Down, Left, Right
    }
}
