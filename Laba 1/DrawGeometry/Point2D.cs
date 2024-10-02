using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGeometry
{
    public class Point2D
    {
        private int X;
        private int Y;

        // Конструктор
        public Point2D(int x, int y) 
        { 
            X = x;
            Y = y;
        }

        // Методы
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }

        public void addX(int x)
        {
            X += x;
        }
        public void addY(int y)
        {
            Y += y;
        }

    }
}
