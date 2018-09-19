using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    abstract class TwoDimensionalShape : Shape
    {
        public override string ToString()
        {
            return $"Area: {Area}\n";
        }
    }
}
