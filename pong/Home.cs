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
            border.Draw(border.X, border.Y); // Draw the border
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, Console.WindowHeight / 2 -1); // Set the cursor so the next line is written in the middle of the screen
            Console.WriteLine("Press enter to start the game");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, Console.WindowHeight / 2); // Set the cursor so the next line is written in the middle of the screen
            Console.WriteLine("For help: pres H");
            ReadOption();
        }

        // Shows the game key info
        public static void ShowInfo()
        {
            Console.Clear();
            border.Draw(border.X, border.Y);

            Console.SetCursorPosition((Console.WindowWidth / 2) - 12, Console.WindowHeight / 2 - 1);
            Console.WriteLine("Keys to move the paddles:");

            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight / 2);
            Console.WriteLine("Player1 = W & S");

            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Player2 = I & K");

            Console.SetCursorPosition((Console.WindowWidth / 2) - 9, Console.WindowHeight / 2 + 3);
            Console.WriteLine("To play press enter");
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
