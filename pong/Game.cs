using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        // Sets all the game assets into variables
        private Border border = new Border();
        private List<Paddle> paddles = new List<Paddle>() // List with the 2 paddles
        {
            new Paddle( ConsoleKey.W, ConsoleKey.S, 1 ),
            new Paddle(ConsoleKey.I, ConsoleKey.K, Console.WindowWidth - 2)
        };
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
            foreach (Paddle paddle in paddles) { paddle.Draw(); }

            // Start the game loop
            while (gameRunning)
            {
                if (Console.KeyAvailable) // If there is a key pressed, check if it is to move a paddle and then move a paddle. This is being done in this function so you dont have to press the key twice
                {
                    ConsoleKey key = Console.ReadKey(true).Key; // Puts the pressed key into the variable key

                    foreach (Paddle paddle in paddles)
                    {
                        if (key == paddle.upKey && paddle.Y > paddle.TopBoundary) // Checks if it is the paddle upKey and if paddle is not on the top of the screen
                        {
                            paddle.Move("up"); // Move paddle up
                        }
                        if (key == paddle.downKey && paddle.Y + paddle.Length < paddle.BottomBoundary) // Checks if it is the paddle downKey and if paddle is not on the bottom of the screen
                        {
                            paddle.Move("down"); // Move paddle down
                        }
                    }
                }

                // Draw the scoreboard above the game area and centered
                scoreboard.Draw();

                // Check for game end conditions
                if (scoreboard.CheckForWinner()) { gameRunning = false; } // If someone won, stop the games

                await Task.Delay(2); // Task delay to control the speed
            }
        }
        public async Task Ball() // This task makes the ball run seperate from the rest of the game so it wont interupt the moving of the paddles
        {
            while (gameRunning)
            {
                ball.Move(); // Update and draw the 
                ball.CheckCollision(scoreboard, paddles); // Check for collisions between the ball and the border or paddles
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
