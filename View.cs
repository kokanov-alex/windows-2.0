using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    internal class View
    {
        internal Point coord;
        internal Point size;
        public View(int x, int y, int w, int h)
        {
            coord = new Point(x, y);
            size = new Point(w, h);
        }

    }
}
