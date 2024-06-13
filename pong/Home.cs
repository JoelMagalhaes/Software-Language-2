using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pong
{
    public class Home : Asset
    {
        private static Border s_border = new Border();
        
        public Home()
        {
        }
        
        public void Show()
        {
            Console.Clear(); // Clear everything from the screen
            s_border.Draw(); // Draw the border

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2); // Sets the cursor at the middle of the screen
            Console.Write("Press enter to start the game");
            Console.SetCursorPosition((Console.WindowWidth / 2), (Console.WindowHeight / 2) + 1); // Move the cursor one line down
            Console.Write("For help: press H");

            ReadOption(); // Reads the pressed key
        }

        public void ShowInfo() // Shows the game key info
        {
            Console.Clear(); // Clear everything from the screen
            s_border.Draw(); // Draw the border

            string message = "Keys to move the paddles:";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), (Console.WindowHeight / 2)); // Sets the cursor at the middle of the screen
            Console.Write(message);
            message = "Player1 = W & S";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), (Console.WindowHeight / 2) + 1); // Move the cursor one line down
            Console.Write(message);
            message = "Player2 = I & K";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), (Console.WindowHeight / 2) + 2); // Move the cursor one line down
            Console.Write(message);
            message = "To play press enter";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), (Console.WindowHeight / 2) + 3); // Move the cursor one line down
            Console.Write(message);

            ReadOption(); // Reads the pressed key
        }

        public static void ReadOption() // Reads the pressed key and does something
        {
            Home Home = new Home();
            ConsoleKey Key = Console.ReadKey(true).Key;
            if (Key == ConsoleKey.H)
            {
                Home.ShowInfo(); // Show the info page
            } 
            else if (Key == ConsoleKey.Escape)
            {
                Home.Show(); // Go back to the start page
            }
            else if (Key == ConsoleKey.Enter)
            {
                return; // Exit the home views
            }
            else
            {
                ReadOption();
            }
        }
    }
}
