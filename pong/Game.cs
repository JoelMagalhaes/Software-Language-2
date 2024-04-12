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

        public Game()
        {
            gameRunning = true; // Starts the game
        }

        public async Task Start()
        {
            Console.Clear(); // Clears the console

            // Draws the assets onto the screen
            border.Draw(); // Draw the border
            ball.Draw();
            paddle1.Draw();
            paddle2.Draw();

            // Start the game loop
            while (gameRunning)
            {
                if (Console.KeyAvailable) // If there is a key pressed, check if it is to move a paddle and then move a paddle. This is being done in this function so you dont have to press the key twice
                {
                    ConsoleKey key = Console.ReadKey(true).Key; // Puts the pressed key into the variable key

                    if (key == paddle1.upKey && paddle1.Y > paddle1.TopBoundary) // Checks if it is the paddle1 upKey and if paddle1 is not on the top of the screen
                    {
                        paddle1.Move("up"); // Move paddle1 up
                    }
                    if (key == paddle1.downKey && paddle1.Y + paddle1.Length < paddle1.BottomBoundary) // Checks if it is the paddle1 downKey and if paddle1 is not on the bottom of the screen
                    {
                        paddle1.Move("down"); // Move paddle1 down
                    }

                    // Handle input for paddle 2
                    if (key == paddle2.upKey && paddle2.Y > paddle2.TopBoundary) // Checks if it is the paddle2 upKey and if paddle2 is not on the top of the screen
                    {
                        paddle2.Move("up"); // Move paddle2 up
                    }
                    if (key == paddle2.downKey && paddle2.Y + paddle2.Length < paddle2.BottomBoundary) // Checks if it is the paddle2 downKey and if paddle2 is not on the bottom of the screen
                    {
                        paddle2.Move("down"); // Move paddle2 down
                    }
                }

                // Check for collisions between the ball and the border or paddles
                ball.CheckPaddleCollision(paddle1);
                ball.CheckPaddleCollision(paddle2);
                ball.CheckBorderCollision(scoreboard);

                // Draw the scoreboard above the game area and centered
                scoreboard.Draw();

                // Check for game end conditions
                if (scoreboard.CheckForWinner()) { gameRunning = false; } // If someone won, stop the games

                await Task.Delay(2); // Task delay to control the speed
            }
        }
        public async Task Ball()
        {
            while (gameRunning)
            {
                ball.Move(); // Update and draw the ball
                await Task.Delay(100); // Task delay to control the speed
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
