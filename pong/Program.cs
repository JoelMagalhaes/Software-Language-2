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
            Console.SetWindowSize(120, 30); // Sets the size of the screen
            Console.CursorVisible = false; // Sets the cursor to invisible

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

