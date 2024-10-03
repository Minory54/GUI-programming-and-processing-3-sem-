using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace EnemyEditor
{
    internal class CIcon
    {
        private string name;
        private string iconPath;
        private int iconWidth;
        private int iconHeight;

        public CIcon(int iconWidth, int iconHeight, string iconPath) 
        { 
            this.iconWidth = iconWidth;
            this.iconHeight = iconHeight;
            this.iconPath = iconPath;
        }

        public string getName() { return name; }
        public string getPath() { return iconPath; }
        public int getIconWidth() { return iconWidth; }
        public int getIconHeight() { return iconHeight; }
    }
}
