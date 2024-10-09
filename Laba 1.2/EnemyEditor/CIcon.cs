using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnemyEditor
{
    internal class CIcon
    {
        public string name { get; }
        public BitmapImage iconPath { get; }
        private int iconWidth;
        private int iconHeight;

        public CIcon(int iconWidth, int iconHeight, string iconPath) 
        { 
            this.iconWidth = iconWidth;
            this.iconHeight = iconHeight;
            this.iconPath = new BitmapImage(new Uri(iconPath));

            name = System.IO.Path.GetFileName(iconPath);
        }

        public string getName() { return name; }
        public BitmapImage getPath() { return iconPath; }
        public int getIconWidth() { return iconWidth; }
        public int getIconHeight() { return iconHeight; }
    }
}
