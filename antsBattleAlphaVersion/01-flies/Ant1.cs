using System;
using System.Drawing;
using System.Linq;
using mazes;

namespace Ants
{
	public class Ant1 : WorldObject
	{
		public Ant1(Point location) : base(location)
		{
		}

		public override void Act(IWorld world)
		{
			var destination = GetDirection(world);
			Destination = Location.Add(destination);
		}

		private Point GetDirection(IWorld world)
		{
		    return random.Next(5) == 0 ? GetRandomDirection(world) : GetDirectionTowardTarget(world);
		}

	    private Point GetRandomDirection(IWorld readonlyWorld)
		{
			var directions = new[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) }
				.Where(d => !readonlyWorld.GetObjectsAt(Location.Add(d)).Any())
				.Concat(new[] { new Point(0, 0)})
				.ToList();
			return directions[random.Next(directions.Count)];
		}

		private Point GetDirectionTowardTarget(IWorld world)
		{
            var endPath = PathFinder1.GetDirectionTo(Location, world);
            var path = new Point(endPath.Y, endPath.X);
            path.X += Location.X;
            path.Y += Location.Y;
            if (world.IsFrogCanEat(endPath))
                world.RemoveObject(this);
		    if (world.Contains<Food>(Location))
		        world.AddStatistic("first");
            return endPath;
        }

		private static readonly Random random = new Random();
	}
}