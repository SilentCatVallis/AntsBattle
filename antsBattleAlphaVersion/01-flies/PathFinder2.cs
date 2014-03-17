using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using mazes;

namespace Ants
{
    public class PathFinder2
    {
        private static IEnumerable<Point> GetNeighbours(Point from, IWorld world)
        {
            //� ���� ������������ ���� ������� ����� ��� ��� �������, �� ��������� ��� ��������� ����� ������������.
            for (int x = from.X - 1; x <= from.X + 1; ++x)
            {
                for (int y = from.Y - 1; y <= from.Y + 1; ++y)
                {
                    var point = new Point(x, y);
                    if (!world.InsideWorld(point) || x == @from.X && y == @from.Y || (x != @from.X && y != @from.Y))
                        continue;
                    if (!world.Contains<Wall>(point) && !world.Contains<Source>(point))
                        yield return new Point(x, y);
                }
            }
        }

        private static Point ReturnPath(Point localPoint, Dictionary<Point, Point> paths, Point startPoint)
        {
            while (paths.ContainsKey(localPoint))
            {
                var point = paths[localPoint];
                if (point == startPoint)
                    return localPoint;
                localPoint = point;
            }
            return Point.Empty;
        }

        public static Point GetDirectionTo(Point source, IWorld world)
        {
            var paths = new Dictionary<Point, Point>();
            var queue = new Queue<Point>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var local = queue.Dequeue();
                if (local == new Point(0, 0))
                {
                    var path = ReturnPath(local, paths, source);
                    return new Point(path.X - source.X, path.Y - source.Y);
                }
                foreach (var neighbour in GetNeighbours(local, world).Where(neighbour => !paths.ContainsKey(neighbour)))
                {
                    queue.Enqueue(neighbour);
                    paths[neighbour] = local;
                }
            }
            return new Point(0, -1);// Point.Empty;
        }
    }
}