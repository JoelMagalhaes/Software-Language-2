using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{ 
    class Program
    { 
        // Main method to start the game
        public static void Main()
        {
            //if (Environment.OSVersion.Platform == PlatformID.Win32NT) { Console.SetBufferSize(120, 30); } // Checks if the platform is Windows, if so set the windows only buffersize.

            Console.SetWindowSize(120, 30); // Set the console window size

            Console.CursorVisible = false; // Sets the cursor to be invisible

            // Start the home page
            Home home = new Home();
            home.Show(); // Shows the opening screen of the game

            // Starts the game
            Game game = new Game();
            Task.WaitAny(game.Start(), game.Ball()); // Start the tasks to play the game, and stops after one is completed

            game.AskAgain(); // Displays the message to play again
        }
    }
}

