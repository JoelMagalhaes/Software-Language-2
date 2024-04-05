using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        private Border border;
        private Paddle paddle1;
        private Paddle paddle2;
        private Scoreboard scoreboard;
        private Ball ball;
        private bool gameRunning;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Initialize game objects here
            border = new Border(2, Console.WindowHeight - 3);
            paddle1 = new Paddle(ConsoleKey.W, ConsoleKey.S); // Assign keys for player 1
            paddle2 = new Paddle(ConsoleKey.I, ConsoleKey.K); // Assign keys for player 2
            scoreboard = new Scoreboard(5); // Best of 5 game
            ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2, 1, 1); // Initial position and velocity of the ball
            gameRunning = true;
        }

        public async Task Start()
        {
            // Prompt the user to resize the console window
            Console.WriteLine("Please resize the console window to your desired size, then press Enter to start the game.");
            Console.ReadLine();

            // Start handling input for both paddles asynchronously
            Task paddle1InputTask = paddle1.HandleInputAsync();
            Task paddle2InputTask = paddle2.HandleInputAsync();

            // Start the game loop
            while (gameRunning)
            {
                // Clear the console
                Console.Clear();

                // Draw the scoreboard above the game area and centered
                scoreboard.Draw(Console.WindowWidth);

                // Redraw the border
                border.Draw(Console.WindowWidth, Console.WindowHeight);

                // Draw the paddles in their current positions
                paddle1.Draw(1);
                paddle2.Draw(Console.WindowWidth - 2);

                // Update and draw the ball
                ball.Move();
                ball.Draw();

                // Check for collisions between the ball and the border
                ball.CheckBorderCollision(Console.WindowWidth, Console.WindowHeight);

                // Check for game end conditions
                if (scoreboard.Player1Wins() || scoreboard.Player2Wins())
                {
                    gameRunning = false;
                }

                // Introduce a small delay to control the game speed
                await Task.Delay(20);
            }

            // Display the winner
            if (scoreboard.Player1Wins())
            {
                Console.WriteLine("Player 1 wins the game!");
            }
            else
            {
                Console.WriteLine("Player 2 wins the game!");
            }
        }

        // Main method to start the game
        public static async Task Main(string[] args)
        {
            Game pongGame = new Game();
            await pongGame.Start();
        }
    }
}
