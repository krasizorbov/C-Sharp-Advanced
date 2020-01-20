using System;
using System.Linq;

namespace RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Rectangle[] rectangles = new Rectangle[counts[0]];

            for (int i = 0; i < counts[0]; i++)
            {
                string[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double x = double.Parse(input[3]);
                double y = double.Parse(input[4]);

                rectangles[i] = new Rectangle(id, width, height, x, y);
            }

            for (int i = 0; i < counts[1]; i++)
            {
                string[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                Rectangle rect1 = rectangles.Where(r => r.Id == input[0]).First();
                Rectangle rect2 = rectangles.Where(r => r.Id == input[1]).First();
                Console.WriteLine(rect1.Intersects(rect2));
            }
        }
    }

    public class Rectangle
    {
        string id;
        double width;
        double height;
        double x;
        double y;

        public string Id { get { return id; } set { id = value; } }

        public double Width { get { return width; } set { width = value; } }

        public double Height { get { return height; } set { height = value; } }

        public double X { get { return x; } set { x = value; } }

        public double Y { get { return y; } set { y = value; } }

        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public string Intersects(Rectangle rectangle)
        {
            if ((rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x >= this.x && rectangle.x <= this.x + this.width) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x >= this.x && rectangle.x <= this.x + this.width))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
