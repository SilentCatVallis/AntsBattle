using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    class Frog : WorldObject
    {
        private const int WantToSleep = 10;
        private const int MounthLength = 5;
        private int _sleepTime = 0;

        public override AntColour GetColourOrNone()
        {
            return AntColour.None;
        }

        public override Object GetObjectType()
        {
            return Object.Frog;
        }

        public override void Act(World world)
        {
            if (_sleepTime >= 0)
            {
                var ants = new List<Point>();
                for (var i = Location.Y - MounthLength; i <= Location.Y + MounthLength; ++i)
                {
                    for (var j = Location.X - MounthLength; j <= Location.X + MounthLength; ++j)
                    {
                        if (world.GetObject(new Point(j, i), AntColour.None) == Object.AnyAnt)
                            ants.Add(new Point(j, i));
                    }
                }
                if (ants.Count == 0)
                    return;
                var rand = new Random();
                var frogTarget = ants[rand.Next(ants.Count)];
                world.RemoveObject(frogTarget);
                _sleepTime = -WantToSleep;
            }
            else
            {
                _sleepTime++;
            }
        }
    }
}
