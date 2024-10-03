using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemyEditor
{
    internal class CIconList
    {
        List<CIcon> icons;

        public CIconList() 
        { 
            icons = new List<CIcon>();
        }

        public void LoadIcons(string path)
        {
            string folder = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + path;
            string filter = "*.png";
            string[] files = Directory.GetFiles(folder, filter);

            foreach (string file in files)
            {
                icons.Add(new CIcon(100, 100, file));
            }
        }

        public void AddIcon(CIcon icon) 
        { 
            icons.Add(icon);
        }
    }
}
