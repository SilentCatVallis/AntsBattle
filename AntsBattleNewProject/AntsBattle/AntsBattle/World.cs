using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public int FrogMouthLength { get; private set; }
        public int FrogWantToSleep { get; private set; }
        public int LifeTime { get; private set; }
        public long Time { get; set; }
        public Size Size { get; private set; }
        public int ObjectsCount { get { return Objects.Count; } }

        public HashSet<WorldObject> Objects = new HashSet<WorldObject>();
        public Dictionary<Point, HashSet<WorldObject>> Cells = new Dictionary<Point, HashSet<WorldObject>>();
        public int WhiteScore { get; set; }
        public int BlackScore { get; set; }

        public IAntAI WhiteAntAI;
        public IAntAI BlackAntAI;

        public World(IList<string> args)
        {
            FrogMouthLength = int.Parse(args[1]);
            FrogWantToSleep = int.Parse(args[2]);
            LifeTime = int.Parse(args[0]);
            var aiImplementationWhite =
                                    Assembly.LoadFrom(args[3]).GetTypes().First(type => type.GetInterfaces().Any(i => i == typeof(IAntAI)));
            var aiImplementationBlack =
                                    Assembly.LoadFrom(args[4]).GetTypes().First(type => type.GetInterfaces().Any(i => i == typeof(IAntAI)));
            WhiteAntAI = (IAntAI)Activator.CreateInstance(aiImplementationWhite);
            BlackAntAI = (IAntAI)Activator.CreateInstance(aiImplementationBlack);
        }

        public void MakeStep()
        {
            if (LifeTime <= 0) return;
            foreach (var obj in Objects.ToList().Where(Objects.Contains))
            {
                RemoveObject(obj);
                obj.Location = obj.Destination;
                AddObject(obj);
                obj.Act(this);
            }
            Time++;
            LifeTime--;
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
            if (!Cells.ContainsKey(obj.Location)) Cells[obj.Location] = new HashSet<WorldObject>();
            Cells[obj.Location].Add(obj);
        }

        public void RemoveObject(WorldObject obj)
        {
            Objects.Remove(obj);
            Cells.Remove(obj.Location);
        }

        public void FreezeWorldSize()
        {
            Size = Objects.Any() ? new Size(Objects.Max(o => o.Location.X) + 1, Objects.Max(o => o.Location.Y) + 1) : new Size(1, 1);
        }
    }
}
