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
        public HashSet<WorldObject> Objects = new HashSet<WorldObject>();
        public Dictionary<Point, HashSet<WorldObject>> Map = new Dictionary<Point, HashSet<WorldObject>>();
        public AIWorld BlackWorld;
        public AIWorld WhiteWorld;
        public int WhiteScore = 0;
        public int BlackScore = 0;

        static readonly Type[] AiImplementation =
                                    Assembly.LoadFrom("a.dll").GetTypes()
                                    .Where(
                                    type => type.GetInterfaces().Any(i => i == typeof(IAntAI))
                                    ).ToArray();

        public IAntAI WhiteAntAI = (IAntAI)Activator.CreateInstance(AiImplementation[0]);
        public IAntAI BlackAntAI = (IAntAI)Activator.CreateInstance(AiImplementation[1]);



        public World()
        {
            BlackWorld = new AIWorld(this, AntColour.Black);
            WhiteWorld = new AIWorld(this, AntColour.White);
            Time = 0;
        }

        public void MakeStep()
        {
            foreach (var obj in Objects)
            {
                Map[obj.Location].Remove(obj);
                obj.Act(this);
                Map[obj.Location].Add(obj);
            }
            Time++;
        }

        public Object GetObject(Point location, AntColour colour)
        {
            var objs = Map[location];
            foreach (var obj in objs)
            {
                if (obj.GetColourOrNone() == AntColour.None)
                    return obj.GetObjectType();
                return obj.GetColourOrNone() == colour ? Object.YourAnt : Object.EnemyAnt;
            }
            return Object.None;
        }

        public void RemoveObject(Point Target)
        {
            var removingObj = Map[Target];
            foreach (var obj in removingObj)
                Objects.Remove(obj);
            Map[Target] = new HashSet<WorldObject>();
        }
    }
}
