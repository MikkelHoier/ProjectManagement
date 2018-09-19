using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralTest
{
    class Quadrilateral
    {
        #region Variables/properties
        protected double X1 { get; set; }
        protected double X2 { get; set; }
        protected double Y1 { get; set; }
        protected double Y2 { get; set; }
        protected double H { get; set; }

        #endregion

        #region constructor
        public Quadrilateral(double x1, double x2, double y1, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public Quadrilateral(double x1, double x2, double y1, double y2, double h)
            : this(x1,x2,y1,y2)
        {
            H = h;
        }
        #endregion
    }
}
