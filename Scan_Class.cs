using System;
namespace Polymorphism
{
    internal static class Scan_Class
    {
        internal static void Scan_Text(ref Window window_1)
        {
            int c = 0;
            int Y = window_1.coord.y + 4, i = 1;
            Console.SetCursorPosition(window_1.coord.x + 2, Y);
            string tmp = " ";
            while (tmp != string.Empty)
            {
                tmp = Console.ReadLine();
                window_1.Text.Add(tmp);
                if (c > window_1.size.x) break;
                Console.SetCursorPosition(window_1.coord.x + 2, Y + i++);
            }
            window_1.Is_Scan_Tetx = true;
        }

        internal static void Scan_Header(ref Window window_1)
        {
            Console.SetCursorPosition(window_1.coord.x, window_1.coord.y);
            string tmp = Console.ReadLine();
            window_1.header = new Header(tmp);
            window_1.Is_Scan_Header = true;
        } 
    }
}
