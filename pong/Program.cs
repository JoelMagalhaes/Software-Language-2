using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{ 
    class Program
    {
        // Main method to start the game
        public static async Task Main(string[] args)
        {
            // Sets the cursor to invisible
            Console.CursorVisible = false;

            // Start the home page
            Home home = new Home();
            Home.Show();

            // Starts the game
            await new Game().Start();

            while (true)
            {
                // Sets the cursor position to the line underneath the win message
                Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 1);

                Console.WriteLine("Do you wanna play again? Press enter");
                // Check the pressed key
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    // If key = enter, start the game again
                    await new Game().Start();
                }
                else
                {
                    // If key is not enter, exit
                    Environment.Exit(0);
                }
            }
        }
    }
}

