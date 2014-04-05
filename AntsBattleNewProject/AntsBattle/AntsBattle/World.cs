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
        public long Time { get; set; }
        public Size Size { get; private set; }
        public int ObjectsCount { get { return Objects.Count; } }
        public HashSet<WorldObject> Objects = new HashSet<WorldObject>();
        public Dictionary<Point, HashSet<WorldObject>> Cells = new Dictionary<Point, HashSet<WorldObject>>();
        public int WhiteScore = 0;
        public int BlackScore = 0;

        static readonly Type AiImplementation =
                                    Assembly.LoadFrom("a.dll").GetTypes()
                                    .Where(
                                    type => type.GetInterfaces().Any(i => i == typeof(IAntAI))
                                    ).First();

        public IAntAI WhiteAntAI = (IAntAI)Activator.CreateInstance(AiImplementation);
        public IAntAI BlackAntAI = (IAntAI)Activator.CreateInstance(AiImplementation);

        public void MakeStep()
        {
            foreach (var obj in Objects.ToList())
            {
                RemoveObject(obj);
                obj.Location = obj.Destination;
                AddObject(obj);
                obj.Act(this);

                //Cells[obj.Location].Remove(obj);
                //obj.Act(this);
                //Cells[obj.Location].Add(obj);
            }
            Time++;
        }

        public Object GetObject(Point location, AntColour colour)
        {
            if (!Cells.ContainsKey(location))
                return Object.None;
            foreach (var obj in Cells[location])
            {
                if (colour == AntColour.None)
                    return obj.GetObjectType();
                if (obj.GetColourOrNone() == AntColour.None)
                    return obj.GetObjectType();
                return obj.GetColourOrNone() == colour ? Object.YourAnt : Object.EnemyAnt;
            }
            return Object.None;
        }

        public void AddObject(WorldObject obj)
        {
            Objects.Add(obj);
            if (!Cells.ContainsKey(obj.Location)) Cells.Add(obj.Location, new HashSet<WorldObject>());
            Cells[obj.Location].Add(obj);
        }

        public void RemoveObject(WorldObject obj)
        {
            Objects.Remove(obj);
            Cells[obj.Location].Remove(obj);
        }

        public void FreezeWorldSize()
        {
            Size = Objects.Any() ? new Size(Objects.Max(o => o.Location.X) + 1, Objects.Max(o => o.Location.Y) + 1) : new Size(1, 1);
        }
    }
}
