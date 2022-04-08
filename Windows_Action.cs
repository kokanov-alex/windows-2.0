using System;
using System.Collections.Generic;

namespace Polymorphism
{

    internal static class Windows_Action
    {
        

        internal static void Exit()
        {
            string s = "Спасибо, что воспользовались нашим консольным приложением)";
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            System.Threading.Thread.Sleep(1600);
            Environment.Exit(0);
        }
        internal static void Window_Is(ref Window window_1, ref List<Window> All_Windows)
        {
            window_1.counter_tab = 0;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                if (All_Windows.Count > 1)
                    for (int i = 0; i < All_Windows.Count - 1; i++)
                    {
                        All_Windows[i].Show_Window();
                        var tmp = All_Windows[i + 1];
                        Drawer.Clean(ref tmp);

                    }

                Console.ForegroundColor = ConsoleColor.White;

                window_1.Show_Window();


                switch (window_1.counter_tab)
                {
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Drawer.Create_Button(window_1.coord, window_1.size, 'X');
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 2:
                        if (All_Windows.Count > 1) Console.ForegroundColor = ConsoleColor.Green;
                        Drawer.Create_Button(window_1.coord, window_1.size, '-');
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Drawer.Create_Button(window_1.coord, window_1.size, '+');
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }


                //вынести в отдельный класс
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();


                if ((consoleKeyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    switch (consoleKeyInfo.Key.ToString())
                    {
                        case "L":
                            window_1.size.x++;
                            break;
                        case "J":
                            int tmp = 0;
                            foreach (string x in window_1.Text)
                                tmp = tmp > x.Length ? tmp : x.Length;
                            tmp = tmp < window_1.header.Head.Length + 6 * 3 ? window_1.header.Head.Length + 6 * 3 : tmp;
                            if (window_1.size.x > tmp + 2)
                                window_1.size.x--;
                            break;
                        case "I":
                            if (window_1.size.y > window_1.Text.Count + 5)
                                window_1.size.y--;
                            break;
                        case "K":
                            window_1.size.y++;
                            break;
                    } 
                }

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Exit();
                        break;
                    case ConsoleKey.Tab:
                        window_1.counter_tab++;
                        window_1.counter_tab = (window_1.counter_tab == Constants.TABS) ? 0 : window_1.counter_tab;
                        break;
                    case ConsoleKey.Enter:
                        if (window_1.counter_tab == 0 && window_1.counter_enter == 0)
                        {
                            if (window_1.Is_Scan_Header)
                                Console.SetCursorPosition(0, 0);

                            else Scan_Class.Scan_Header(ref window_1);
                            window_1.counter_enter++;
                        }
                        else if (window_1.counter_tab == 0 && window_1.counter_enter == 1)
                        {
                            if (window_1.Is_Scan_Tetx)
                                Console.SetCursorPosition(0, 0);

                            else Scan_Class.Scan_Text(ref window_1);
                        }
                        else if(window_1.counter_tab > 0)
                        {
                            Button_Comands_Class.Button_Comands(ref All_Windows, ref window_1);
                            return;
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (window_1.coord.y > 1)
                            window_1.coord.y--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (window_1.coord.y + window_1.size.y < Constants.BORDER_Y)
                            window_1.coord.y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (window_1.coord.x > 1)
                            window_1.coord.x--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (window_1.coord.x + window_1.size.x < Constants.BORDED_X)
                            window_1.coord.x++;
                        break;

                }
            }
        }
    }
}


