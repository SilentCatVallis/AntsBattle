using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    public class WhiteAnt : WorldObject
    {
        public override Object GetObjectType()
        {
            return Object.AnyAnt;
        }

        public override AntColour GetColourOrNone()
        {
            return AntColour.White;
        }

        public override void Act(World world)
        {
            //Direction direction = GetDirection(world);
            Direction direction = world.WhiteAntAI.GetDirection(Location, world.WhiteWorld);
            Destination = Location;
            if (direction == Direction.Up)
                Destination.Y += 1;
            if (direction == Direction.Down)
                Destination.Y -= 1;
            if (direction == Direction.Left)
                Destination.X -= 1;
            if (direction == Direction.Right)
                Destination.X += 1;
            if (world.GetObject(Destination, AntColour.White) == Object.Food ||
                world.GetObject(Destination, GetColourOrNone()) == Object.None)
                Location = Destination;
        }

        private static Direction GetDirection(World world)
        {
            var e = world.WhiteWorld;
            //
            return Direction.Down;
        }
    }
}
