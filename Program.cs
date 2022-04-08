using System;
using System.Collections.Generic;

namespace Polymorphism
{
    internal class Program
    {
        internal static void Main()
        {
            Console.Title = "Консольное приложение";
            All_Windows All_win = new All_Windows();
            Constants Consts = new Constants();
            var tmp = new Window(25, 7, 45, 15, new Header(""));
            All_win.all_windows.Add(tmp);            
            Windows_Action.Window_Is(ref tmp, ref All_win.all_windows);
        }
    }
}

