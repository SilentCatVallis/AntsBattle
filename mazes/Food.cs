using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mazes
{
    public class Food : WorldObject
    {
        public Food(Point location) : base(location)
        {
        }

        public override void Act(IWorld world)
        {
            var flag = false;
            foreach (var obj in world.GetObjectsAt(Location).Where(obj => !(obj is Wall) && !(obj is Frog) && !(obj is Food)))
                flag = true;
            if (flag)
                world.RemoveObject(this);
        }

        //private static readonly Random random = new Random();
    }
}
