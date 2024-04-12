using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        // Sets all the game assets into variables
        private Border border = new Border();
        private Paddle paddle1 = new Paddle(ConsoleKey.W, ConsoleKey.S, 1); // Assign keys for player 1
        private Paddle paddle2 = new Paddle(ConsoleKey.I, ConsoleKey.K, Console.WindowWidth - 2); // Assign keys for player 2
        private Scoreboard scoreboard = new Scoreboard(5); // Best of 5 game
        private Ball ball = new Ball(1, 1); // Initial position and velocity of the ball
        private bool gameRunning;

        private readonly static object gameLock = new object(); // Makes a lock so you cant draw two things at once

        public Game()
        {
            gameRunning = true; // Starts the game
        }

        public async Task Start()
        {
            Console.Clear(); // Clears the console
            border.Draw(); // Draw the border
            ball.Draw();

            // Start handling input for both paddles asynchronously
            _ = Task.Run(paddle1.HandleInput);
            _ = Task.Run(paddle2.HandleInput);


            // Start the game loop
            while (gameRunning)
            {
                // Draw the scoreboard above the game area and centered
                lock (gameLock) { scoreboard.Draw(); }


                // Draw the paddles in their current positions
                // Int given is the x axis position of the paddle
                lock (gameLock) { paddle1.Draw(); }
                lock (gameLock) { paddle2.Draw(); }

                // Check for collisions between the ball and the border or paddles
                ball.CheckPaddleCollision(paddle1);
                ball.CheckPaddleCollision(paddle2);
                ball.CheckBorderCollision(Console.WindowWidth, Console.WindowHeight, scoreboard);

                // Check for game end conditions
                if (scoreboard.CheckForWinner()) { gameRunning = false; } // If someone won, stop the games

                await Task.Delay(800); // Task delay to control the speed
            }
        }
        public async Task Ball()
        {
            while (gameRunning)
            {
                lock (gameLock) { ball.Move(); } // Update and draw the ball
                await Task.Delay(500); // Task delay to control the speed
            }
        }

        public void AskAgain()
        {
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 1); // Writes the message on the specified line
                Console.Write("Do you wanna play again? Press enter"); // Sets the message

                ConsoleKey key = Console.ReadKey(true).Key; // Check the pressed key
                if (key == ConsoleKey.Enter)
                {
                    // If key = enter, start the game again
                    Game game = new Game();
                    Task.WaitAny(game.Start(), game.Ball());
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
