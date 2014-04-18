using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    class BlackAnt : WorldObject
    {
        public BlackAnt(Point location) : base(location)
		{
        }

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
            var direction = world.BlackAntAI.GetDirection(Location, new AIWorld(world, AntColour.Black));
            var destination = new Point(0, 0);
            if (direction == Direction.Up)
                destination.Y += 1;
            if (direction == Direction.Down)
                destination.Y -= 1;
            if (direction == Direction.Left)
                destination.X -= 1;
            if (direction == Direction.Right)
                destination.X += 1;
            if ((world.GetObject(Location.Add(destination), AntColour.Black) == Object.Food ||
                world.GetObject(Location.Add(destination), AntColour.Black) == Object.None))
                Destination = Location.Add(destination);
            if (world.GetObject(Destination, AntColour.Black) == Object.Food)
            {
                world.RemoveObject(world.Cells[Destination].First(x => x.GetObjectType() == Object.Food));
                world.BlackScore++;
            }
            if (world.GetObject(Location, AntColour.Black) == Object.Food)
            {
                world.RemoveObject(world.Cells[Location].First(x => x.GetObjectType() == Object.Food));
                world.BlackScore++;
            }
        }
    }
}
