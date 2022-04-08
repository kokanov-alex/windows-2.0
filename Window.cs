using System;
using System.Collections.Generic;

namespace Polymorphism
{
    internal class Window : View
    {
        internal Header header;
        internal List<string> Text;
        internal int counter_tab;
        internal int counter_enter;
        internal bool Is_Scan_Tetx;
        internal bool Is_Scan_Header;
        internal Window(int x, int y, int w, int h, Header header) : base(x, y, w, h)
        {
            this.header = header;
            counter_tab = 0;
            counter_enter = 0;
            Text = new List<string>();
            Is_Scan_Tetx = false;
        }

        internal void Show_Window()
        {
            Drawer.Create_Pic(coord, size);
            Drawer.Print_gor_line(new Point(coord.x + 1, coord.y + 3), size.x - 2, ".");
            Drawer.Create_Button(coord, size, 'X');
            Drawer.Create_Button(coord, size, '-');
            Drawer.Create_Button(coord, size, '+');
            Drawer.Create_Header(header, coord);
            
            if (Text.Count > 0)
            {
                int Y = coord.y + 4, i = 1;
                Console.SetCursorPosition(coord.x + 2, Y);
                foreach (var item in Text)
                {
                    Console.WriteLine(item);
                    Console.SetCursorPosition(coord.x + 2, Y + i++);
                }
            }
            Console.SetCursorPosition(0, 0);
        }

    }
}
