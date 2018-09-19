using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(15);
            Square square = new Square(15);
            Sphere sphere = new Sphere(15);
            Cube cube = new Cube(15);

            var shapes = new List<Shape>() { circle, square, sphere, cube };

            foreach(var currentShape in shapes)
            {
                Console.WriteLine(currentShape);
            }

            Console.ReadLine();
        }
    }
}
