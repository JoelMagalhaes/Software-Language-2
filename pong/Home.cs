using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pong
{
    public class Home
    {
        private static Border border = new Border();
        
        public Home()
        {
        }
        
        public static void Show()
        {
            border.Draw(Console.WindowWidth, Console.WindowHeight);
            Console.SetCursorPosition((Console.WindowWidth /  2) - 25, Console.WindowHeight / 2 - 1);
            // Prompt the user to resize the console window
            Console.WriteLine("Please resize the console window to your desired size");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, Console.WindowHeight / 2);
            Console.WriteLine("Press enter to start the game");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.WindowHeight / 2 + 1);
            Console.WriteLine("For help: pres H");
            ReadOption();
        }

        public static void ShowInfo()
        {
            Console.WriteLine("Player1 = W & S");
            Console.WriteLine("Player2 = I & K");
            ReadOption();
        }

        public static async void ReadOption()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.H)
            {
                ShowInfo();
            } 
            else if (key == ConsoleKey.Escape)
            {
                Show();
            }
            else if (key == ConsoleKey.Enter)
            {
                return;
            }
            else
            {
                ReadOption();
            }
            await Task.Delay(1);
        }
    }
}
