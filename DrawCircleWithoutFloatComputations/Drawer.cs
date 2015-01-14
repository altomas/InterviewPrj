using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawCircleWithoutFloatComputations
{
    public class Drawer
    {
      public Point[] Circle(int radius)
      {
        List<Point> result = new List<Point>();

        for (int i = 0; i <= radius / 2; i++)
        {
          int x = radius - i;

          while (radius * radius > ((x * x) + i * i))
          {
            x++;
          }

          result.Add(new Point() { X = x, Y = i });
          result.Add(new Point() { X = i, Y = x });

          result.Add(new Point() { X = -x, Y = i });
          result.Add(new Point() { X = -i, Y = x });

          result.Add(new Point() { X = -x, Y = -i });
          result.Add(new Point() { X = -i, Y = -x });

          result.Add(new Point() { X = x, Y = -i });
          result.Add(new Point() { X = i, Y = -x });
        }


        return result.ToArray();
      }
    }

    public class Point
    {
      public int X { get; set; }
      public int Y { get; set; }

      public override bool Equals(object obj)
      {
        var point = obj as Point;
 
        if (point == null)
        {
          return false;
        }

        return this.X == point.X && this.Y == point.Y;
      }

      public override int GetHashCode()
      {
        return this.ToString().GetHashCode();
      }

      public override string ToString()
      {
        return string.Format("X:({0});Y:({1})", X, Y);
      }
    }
  }
