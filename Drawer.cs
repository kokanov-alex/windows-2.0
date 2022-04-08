using System;
using System.Collections.Generic;

namespace Polymorphism
{
    internal static class Drawer
    {
        internal static void Print_gor_line(Point cords, int w, string s)
        {
            Console.SetCursorPosition(cords.x - 1, cords.y);
            for (int i = 0; i < w + 3; i++)
            {
                Console.Write(s);
                Console.SetCursorPosition(cords.x + i, cords.y);
            }
        }

        internal static void Print_vert_line(Point cords, int h, string s)
        {
            Console.SetCursorPosition(cords.x, cords.y);
            for (int i = 0; i < h; i++)
            {
                Console.Write(s);
                Console.SetCursorPosition(cords.x, cords.y + i);
            }
        }

        internal static void Create_Pic(Point cords, Point size)
        {
            View view = new View(cords.x, cords.y, size.x, size.y);
            Print_gor_line(new Point(view.coord.x, view.coord.y - 1), view.size.x, ".");
            Print_vert_line(new Point(view.coord.x - 1, view.coord.y), view.size.y, "|");
            Print_gor_line(new Point(view.coord.x + 1, view.coord.y + view.size.y - 2), view.size.x - 1, ".");
            Print_vert_line(new Point(view.coord.x + view.size.x + 1, view.coord.y), view.size.y, "|");

        }


        internal static void Create_Button(Point Cords_View, Point Size_View, char sim)
        {
            var simbols = new Dictionary<char, int>() { ['0'] = 3, ['+'] = 2, ['-'] = 1, ['X'] = 0 };
            Print_vert_line(new Point(Cords_View.x + Size_View.x - 5 - 6 * simbols[sim], Cords_View.y + 1), 1, "|");
            Print_vert_line(new Point(Cords_View.x + Size_View.x - 1 - 6 * simbols[sim], Cords_View.y + 1), 1, "|");
            Print_gor_line(new Point(Cords_View.x + Size_View.x - 4 - 6 * simbols[sim], Cords_View.y), 2, "*");
            Print_gor_line(new Point(Cords_View.x + Size_View.x - 4 - 6 * simbols[sim], Cords_View.y + 2), 2, "*");
            Console.SetCursorPosition(Cords_View.x + Size_View.x - 3 - 6 * simbols[sim], Cords_View.y + 1);
            Console.Write(sim);
        }
        internal static void Create_Header(Header header, Point cords)
        {
            Console.SetCursorPosition(cords.x, cords.y);
            Console.Write(header.Head);
        }

        internal static void Clean(ref Window window_1)
        {
            for (int i = window_1.coord.y; i <= window_1.coord.y + window_1.size.y - 2; i++)
            {
                Console.SetCursorPosition(window_1.coord.x, i);

                for (int j = 0; j < window_1.size.x + 2; j++)
                {
                    Console.Write(" ");
                }
            }

        }
    }
}
