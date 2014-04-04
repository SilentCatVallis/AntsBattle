using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    public class WhiteAnt : WorldObject
    {
        public WhiteAnt(Point location) : base(location)
		{
        }

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
            var direction = world.WhiteAntAI.GetDirection(Location, new AIWorld(world, AntColour.White));
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
                world.GetObject(Destination, AntColour.White) == Object.None)
                Location = Destination;
            if (world.GetObject(Destination, AntColour.White) != Object.Food) return;
            world.RemoveObject(Destination);
            world.WhiteScore++;
        }
    }
}
