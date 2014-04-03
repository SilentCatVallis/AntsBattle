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
        private AntColour Colour;
        private readonly World _world;

        public AIWorld(World world, AntColour colour)
        {
            Colour = colour;
            _world = world;
        }

        public Object GetObjectInCell(Point location)
        {
            return  _world.GetObject(location, Colour);
        }

        public Size GetMapSize()
        {
            return _world.Size;
        }


    }
}
