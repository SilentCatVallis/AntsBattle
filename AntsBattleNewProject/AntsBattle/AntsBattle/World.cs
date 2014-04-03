using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AntsBattle
{
    public enum AntColour
    {
        Black, White, None
    }

    public class World
    {
        public int Time;
        public Size Size { get; private set; }
        public readonly HashSet<WorldObject> Objects = new HashSet<WorldObject>();
        public Dictionary<Point, HashSet<WorldObject>> Map = new Dictionary<Point, HashSet<WorldObject>>();
        public AIWorld BlackWorld;
        public AIWorld WhiteWorld;

        static readonly Type aiImplementation =
                                    Assembly.LoadFrom("a.dll").GetTypes()
                                    .First(
                                    type => type.GetInterfaces().Any(i => i == typeof(IAntAI))
                                    );

        public IAntAI WhiteAntAI = (IAntAI) Activator.CreateInstance(aiImplementation);
      

        public World()
        {
            BlackWorld = new AIWorld(this, AntColour.Black);
            WhiteWorld = new AIWorld(this, AntColour.White);
            Time = 0;
        }

        public void MakeStep()
        {
            foreach (var obj in Objects)
                obj.Act(this);
            Time++;
        }

        public Object GetObject(Point location, AntColour colour)
        {
            var objs = Map[location];
            foreach (var obj in objs)
                if (obj.GetColourOrNone() == colour)
                    return Object.YourAnt;
                else if (obj.GetColourOrNone() == AntColour.None)
                    return obj.GetObjectType();
                else
                    return Object.EnemyAnt;
            return Object.None;
        }
    }
}
