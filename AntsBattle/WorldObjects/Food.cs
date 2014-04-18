using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    class Food : WorldObject
    {
        public Food(Point location) : base(location)
		{
        }

        //public override void Act(World world)
        //{
        //    foreach (var obj in world.Cells[Location])
        //    {
        //        if (obj.GetColourOrNone() == AntColour.White)
        //        {
        //            world.WhiteScore++;
        //            world.RemoveObject(this);
        //        }
        //        if (obj.GetColourOrNone() == AntColour.Black)
        //        {
        //            world.BlackScore++;
        //            world.RemoveObject(this);
        //        }
        //    }
        //}

        public override Object GetObjectType()
        {
            return Object.Food;
        }
    }
}
