using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    class Cube : ThreeDimensionalShape
    {
        private double length;

        public Cube(double length)
        {
            Length = length;
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public override double Area => 6 * (Length * Length);
        public override double Volume => Length * Length * Length;
    }
}
