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
            Console.SetWindowSize(120, 30);
            // Sets the cursor to invisible
            Console.CursorVisible = false;

            // Start the home page
            Home home = new Home();
            Home.Show();

            // Starts the game
            Game game = new Game();
            Task.WaitAny(game.Start(), game.Ball());

            game.AskAgain();
        }
    }
}

