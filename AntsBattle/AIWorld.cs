using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    public enum Object
    {
        None, EnemyAnt, Wall, Frog, YourAnt, Food, AnyAnt
    }

    public class AIWorld
    {
        private readonly AntColour _colour;
        private readonly World _world;

        public AIWorld(World world, AntColour colour)
        {
            _colour = colour;
            _world = world;
        }

        public Object GetObjectInCell(Point location)
        {
            return  _world.GetObject(location, _colour);
        }

        public Size MapSize { get { return _world.Size; } }
        public int FrogSleepTime { get { return _world.FrogWantToSleep; } }
        public int FrogMouthLength { get { return _world.FrogMouthLength; } }
    }
}
