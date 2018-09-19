using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    class Sphere : ThreeDimensionalShape
    {
        private double radius;        

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public override double Area => 4 * Math.PI * (Radius * Radius);

        public override double Volume => 0.75 * Math.PI * (Radius * Radius * Radius);
    }
}
