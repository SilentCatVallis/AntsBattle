using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    class BlackAnt : WorldObject
    {
        public override Object GetObjectType()
        {
            return Object.AnyAnt;
        }

        public override AntColour GetColourOrNone()
        {
            return AntColour.Black;
        }

        public override void Act(World world)
        {
            Direction direction = GetDirection(world);
        }

        private static Direction GetDirection(World world)
        {
            var e = world.WhiteWorld;
            //
            return Direction.Up;
        }
    }
}
