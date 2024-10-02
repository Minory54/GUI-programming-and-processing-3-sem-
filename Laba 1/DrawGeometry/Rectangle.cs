using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGeometry
{
    public class Rectangle
    {
        private Point2D point1;
        private Point2D point2;
        private Point2D point3;
        private Point2D point4;

        private Point2D center;

        // Конструктор
        public Rectangle(Point2D point1, Point2D point2, Point2D point3, Point2D point4)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            this.point4 = point4;
        }

        // Методы
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
        public Point2D getPoint4()
        {
            return point4;
        }

        public void addX(int X)
        {
            point1.addX(X);
            point2.addX(X);
            point3.addX(X);
            point4.addX(X);
        }
        public void addY(int Y)
        {
            point1.addY(Y);
            point2.addY(Y);
            point3.addY(Y);
            point4.addY(Y);
        }

        public Point2D getCenter() 
        {
            Point2D center = new Point2D((point1.getX() + point2.getX() + point3.getX() + point4.getX()) / 4, (point1.getY() + point2.getY() + point3.getY() + point3.getY()) / 4);
            return center;
        }
    }
}
