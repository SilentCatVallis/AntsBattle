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
            var direction = world.WhiteAntAI.GetDirection(Location, new AIWorld(world, AntColour.White));
            var destination = new Point(0, 0);
            if (direction == Direction.Up)
                destination.Y += 1;
            if (direction == Direction.Down)
                destination.Y -= 1;
            if (direction == Direction.Left)
                destination.X -= 1;
            if (direction == Direction.Right)
                destination.X += 1;
            if (world.GetObject(Location.Add(destination), AntColour.White) == Object.Food ||
                world.GetObject(Location.Add(destination), AntColour.White) == Object.None)
                Destination = Location.Add(destination);
            if (world.GetObject(Destination, AntColour.White) == Object.Food)
            {
                world.RemoveObject(world.Cells[Destination].First(x => x.GetObjectType() == Object.Food));
                world.WhiteScore++;
            }
            if (world.GetObject(Location, AntColour.White) == Object.Food)
            {
                world.RemoveObject(world.Cells[Location].First(x => x.GetObjectType() == Object.Food));
                world.WhiteScore++;
            }
        }
    }
}
