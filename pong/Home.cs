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

            this.Messages = new string[] { "Press enter to start the game", "For help: press H" }; // Sets the messages that are going to be dispayed
            Message(); // Displays the messages from the messages array in the middle of the screen

            ReadOption(); // Reads the pressed key
        }

        public void ShowInfo() // Shows the game key info
        {
            Console.Clear(); // Clear everything from the screen
            s_border.Draw(); // Draw the border

            this.Messages = new string[] { "Keys to move the paddles:", "Player1 = W & S", "Player2 = I & K", "To play press enter" }; // Array with all the lines of the info screen

            Message(); // Displays the messages

            ReadOption();
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
