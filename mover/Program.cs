using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mover
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        static void Main(string[] args)
        {
            ConsoleSpiner spin = new ConsoleSpiner();
            Console.WindowWidth = 40;
            Console.WindowHeight = 10;
            Console.CursorVisible = false;
            Console.WriteLine("Press ESC to stop");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Im Working....");
            int i = 600;
            int count = 0;
            do
            {
                while (!Console.KeyAvailable)
                {
                    SetCursorPos(i, 500);
                    Thread.Sleep(300);
                    spin.Turn();
                    i = i == 600 && count % 10 == 0 ? 500 : 600;
                    count++;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public class ConsoleSpiner
        {
            int counter;
            public ConsoleSpiner()
            {
                counter = 0;
            }
            public void Turn()
            {
                counter++;
                switch (counter % 4)
                {
                    case 0: Console.Write("|"); break;
                    case 1: Console.Write("/"); break;
                    case 2: Console.Write("-"); break;
                    case 3: Console.Write("\\"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
