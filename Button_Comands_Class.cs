using System;
using System.Collections.Generic;


namespace Polymorphism
{
    public static class Button_Comands_Class
    {
        internal static Tuple<int, int> Get_Cords(Window win)
        {
            
            int x = 0, y = 0;
            if (win.coord.x < 4 || win.coord.y < 4)
            {
                x = win.coord.x + 2;
                y = win.coord.y + 2;
            }
            else if (win.coord.x + win.size.y > Constants.BORDER_Y - 4 ||
               win.coord.y + win.size.x > Constants.BORDED_X - 4)
            {
                x = win.coord.x - 2;
                y = win.coord.y - 2;
            }
            Tuple<int, int> cords = Tuple.Create(x, y);
            return cords;
        }

        internal static void Button_Comands(ref List<Window> All_Windows, ref Window window_1)
        {
            string[] actios = { "create", "collapse", "remove" };

            Console.Clear();
            switch (actios[window_1.counter_tab - 1])
            {
                case "create":
                    var w = All_Windows[All_Windows.Count - 1];
                    var cords = Get_Cords(w);
                    var tmp = new Window(cords.Item1, cords.Item2, Constants.SIZE_X, Constants.SIZE_Y, new Header(""));
                    All_Windows.Add(tmp);
                    Windows_Action.Window_Is(ref tmp, ref All_Windows);
                    break;
                case "collapse":
                    //сделать вкладки для свёрнутых окон
                    if (All_Windows.Count > 1)
                    {
                        var first_win = All_Windows[All_Windows.Count - 1];
                        for (int i = All_Windows.Count - 2; i >= 0; i--)
                        {
                            All_Windows[i + 1] = All_Windows[i];
                        }
                        All_Windows[0] = first_win;
                        var qq = All_Windows[All_Windows.Count - 1];
                        Windows_Action.Window_Is(ref qq, ref All_Windows);

                    }
                    var r = All_Windows[All_Windows.Count - 1];
                    Windows_Action.Window_Is(ref r, ref All_Windows);
                    break;
                case "remove":
                    All_Windows.Remove(window_1);
                    if (All_Windows.Count == 0)
                        Windows_Action.Exit();
                    var t = All_Windows[All_Windows.Count - 1];
                    Windows_Action.Window_Is(ref t, ref All_Windows);
                    break;
            }
        }
    }
}
