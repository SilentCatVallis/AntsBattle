using System.Drawing;
using mazes;

namespace Ants
{
	public class Source : WorldObject
	{
		public Source(Point location) : base(location)
		{
		}

		public override void Act(IWorld world)
		{
			if (world.Time%4 == 0 && world.ObjectsCount < 1000)
                world.AddObject(new Ant(Location));
		}
	}
}