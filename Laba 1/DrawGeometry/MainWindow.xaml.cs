using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawGeometry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        
        Triangle triangle;
        Rectangle rectangle;

        int LastSliderValueX, LastSliderValueY;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Triangle_Click(object sender, RoutedEventArgs e)
        {
            rectangle = null;

            Point2D point1 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), rnd.Next(5, (int)Scene.Height - 5));
            Point2D point2 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), rnd.Next(5, (int)Scene.Height - 5));
            Point2D point3 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), rnd.Next(5, (int)Scene.Height - 5));
            triangle = new Triangle(point1, point2, point3);

            SetSliderValue(triangle.getCenter());
            DrawTriangle(triangle);
        }

        private void btn_Rectangle_Click(object sender, RoutedEventArgs e)
        {
            triangle = null;

            Point2D point1 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), rnd.Next(5, (int)Scene.Height - 5));
            Point2D point2 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), point1.getY());
            Point2D point3 = new Point2D(point2.getX(), rnd.Next(0, (int)Scene.Height - 10));
            Point2D point4 = new Point2D(point1.getX(), point3.getY());
            rectangle = new Rectangle(point1, point2, point3, point4);

            SetSliderValue(rectangle.getCenter());
            DrawRectangle(rectangle);
        }

        private void btn_Square_Click(object sender, RoutedEventArgs e)
        {
            triangle = null;
           
            Point2D point1 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), rnd.Next(5, (int)Scene.Height - 5));
            Point2D point2 = new Point2D(rnd.Next(5, (int)Scene.Width - 5), point1.getY());
            //Point2D point2 = new Point2D(rnd.Next(point1.getX(), point1.getX() + ((int)Scene.Width - point1.getY())), point1.getY());
            //btn_Square.Content = Convert.ToString(point1.getX() + ((int)Scene.Width - point1.getY()));
            Point2D point3 = new Point2D(point2.getX(), point2.getY() + getLenth(point1, point2));
            Point2D point4 = new Point2D(point1.getX(), point3.getY());
            rectangle = new Rectangle(point1, point2, point3, point4);

            SetSliderValue(rectangle.getCenter());
            DrawRectangle(rectangle);
        }

        public void SetSliderValue(Point2D center) 
        {
            sl_X.Value = center.getX();
            sl_Y.Value = center.getY();
            LastSliderValueX = (int)sl_X.Value;
            LastSliderValueY = (int)sl_Y.Value;
        }

        public void DrawPoint(Point2D point1)
        {
            Point point = new Point(point1.getX(), point1.getY());
            Ellipse elipse = new Ellipse();

            elipse.Width = 4;
            elipse.Height = 4;

            elipse.Fill = Brushes.Black;
            elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);

            Scene.Children.Add(elipse);
        }

        public void DrawLine(Point2D point1, Point2D point2)
        {
            Line line = new Line();

            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;

            line.X1 = point1.getX();
            line.Y1 = point1.getY();

            line.X2 = point2.getX();
            line.Y2 = point2.getY();

            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle triangle)
        {
            ClearScene();
            DrawLine(triangle.getPoint1(), triangle.getPoint2());
            DrawLine(triangle.getPoint2(), triangle.getPoint3());
            DrawLine(triangle.getPoint3(), triangle.getPoint1());

            DrawPoint(triangle.getCenter());
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            ClearScene();
            DrawLine(rectangle.getPoint1(), rectangle.getPoint2());
            DrawLine(rectangle.getPoint2(), rectangle.getPoint3());
            DrawLine(rectangle.getPoint3(), rectangle.getPoint4());
            DrawLine(rectangle.getPoint4(), rectangle.getPoint1());

            DrawPoint(rectangle.getCenter());
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }

        public int getLenth (Point2D pointStart, Point2D pointEnd)
        {
            int result = Convert.ToInt32(Math.Sqrt(Math.Pow(pointEnd.getX() - pointStart.getX(), 2) + Math.Pow(pointEnd.getY() - pointStart.getY(), 2)));
            return result;
        }

        private void sl_X_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValueX = (int)sl_X.Value;

            if (SliderValueX < LastSliderValueX)
            {
                ShiftX(-1);
            }
            else 
            {
                ShiftX(1);
            }

            LastSliderValueX = SliderValueX;
        }

        public void ShiftX(int value)
        {
            if (rectangle != null)
            { 
                rectangle.addX(value);
                DrawRectangle(rectangle);
            }
            else if (triangle != null)
            {
                triangle.addX(value);
                DrawTriangle(triangle);

            }
        }

        private void sl_Y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValueY = (int)sl_Y.Value;

            if (SliderValueY < LastSliderValueY)
            {
                ShiftY(-1);
            }
            else
            {
                ShiftY(1);
            }

            LastSliderValueY = SliderValueY;
        }

        public void ShiftY(int value)
        {
            if (rectangle != null)
            {
                rectangle.addY(value);
                DrawRectangle(rectangle);
            }
            else if (triangle != null)
            {
                triangle.addY(value);
                DrawTriangle(triangle);
            }
        }
    }
}
