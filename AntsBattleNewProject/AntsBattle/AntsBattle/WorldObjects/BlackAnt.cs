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
            var direction = world.BlackAntAI.GetDirection(Location, world.WhiteWorld);
            Destination = Location;
            if (direction == Direction.Up)
                Destination.Y += 1;
            if (direction == Direction.Down)
                Destination.Y -= 1;
            if (direction == Direction.Left)
                Destination.X -= 1;
            if (direction == Direction.Right)
                Destination.X += 1;
            if (world.GetObject(Destination, AntColour.Black) == Object.Food ||
                world.GetObject(Destination, AntColour.Black) == Object.None)
                Location = Destination;
        }
    }
}
