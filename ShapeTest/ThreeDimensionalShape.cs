using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    abstract class ThreeDimensionalShape : Shape
    {
        public abstract double Volume
        {
            get;
        }

        public override string ToString()
        {
            return $"Area: {Area}\n" +
                $"Volume:{Volume}\n";
        }
    }
}
