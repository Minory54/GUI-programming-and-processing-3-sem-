using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGeometry
{
    internal class Triangle
    {
        private Point2D point1;
        private Point2D point2;
        private Point2D point3;

        public Triangle(Point2D point1, Point2D point2, Point2D point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        public Point2D getPoint1()
        {
            return point1;
        }
        public Point2D getPoint2()
        {
            return point2;
        }
        public Point2D getPoint3()
        {
            return point3;
        }
    }
}
