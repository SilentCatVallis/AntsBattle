using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;

namespace mazes
{
	public class World : IWorld
	{
	    public Statistic statistic = new Statistic();

	    public void AddStatistic(string player)
	    {
	        if (player == "first")
	            statistic.FirstPlayer++;
	        else
	            statistic.SecondPlayer++;
	    }
        public readonly int MouthLength = 5;
        public int frogWait = 0;
        public int digestionTime = -7;
        public readonly HashSet<WorldObject> Objects = new HashSet<WorldObject>();
		public Dictionary<Point, HashSet<WorldObject>> Cells = new Dictionary<Point, HashSet<WorldObject>>();
		//public Point Cursor { get; set; }
		public long Time { get; set; }
		public int ObjectsCount { get { return Objects.Count; } }

        public bool IsFrogCanEat(Point ant)
        {
            foreach (var obj in Objects)
                if (obj is Frog)
                    if (Math.Abs(obj.Location.X - ant.X) < MouthLength && Math.Abs(obj.Location.Y - ant.Y) < MouthLength && frogWait >= 0)
                        return true;
            return false;
        }



        public void AddObject(WorldObject obj)
		{
			Objects.Add(obj);
			if (!Cells.ContainsKey(obj.Location)) Cells.Add(obj.Location, new HashSet<WorldObject>());
			Cells[obj.Location].Add(obj);
		}

		public bool InsideWorld(Point location)
		{
			return location.X >= 0 && location.Y >= 0 && location.X < Size.Width && location.Y < Size.Height;
		}

		public void RemoveObject(WorldObject obj)
		{
			Objects.Remove(obj);
			Cells[obj.Location].Remove(obj);
		}

		public IEnumerable<WorldObject> GetObjectsAt(Point location)
		{
			return Cells.ContainsKey(location) ? Cells[location] : Enumerable.Empty<WorldObject>();
		}

		public bool Contains<T>(Point location)
		{
			return GetObjectsAt(location).Any(o => o is T);
		}

        public void GenerateNewFood()
        {
            if (Time%10 != 0 || ObjectsCount >= 1000)
                return;
            var point = new Point(random.Next(Size.Width - 2) + 1, random.Next(Size.Height - 2) + 1);
            if (Contains<Wall>(point) || Contains<Frog>(point))
                return;
            AddObject(new Food(point));
            var simmetricPoint = new Point(Size.Width - point.X - 1, Size.Height - point.Y - 1);
            AddObject(new Food(simmetricPoint));
        }

	    public void EatAnt(WorldObject obj)
	    {
	        RemoveObject(obj);
	        frogWait = digestionTime;
	    }

		public void MakeStep()
		{
            Time++;
            if (frogWait < 0)
                frogWait++;
            var ants = new List<WorldObject>();
            var others = new List<WorldObject>();
            foreach (var obj in Objects.ToList())
			{
                if(!(obj is Wall) && !(obj is Frog) && !(obj is Food))
                    ants.Add(obj);
                else
                    others.Add(obj);
			}
		    foreach (var ant in ants)
		    {
                RemoveObject(ant);
                ant.Location = ant.Destination;
                AddObject(ant);
                ant.Act(this);
            }
            foreach (var other in others)
            {
                RemoveObject(other);
                other.Location = other.Destination;
                AddObject(other);
                other.Act(this);
            }
            GenerateNewFood();
        }

		public void FreezeWorldSize()
		{
			Size = Objects.Any() ? new Size(Objects.Max(o => o.Location.X) + 1, Objects.Max(o => o.Location.Y) + 1) : new Size(1, 1);
		}

        private static readonly Random random = new Random();
        public Size Size { get; private set; }
	}
}