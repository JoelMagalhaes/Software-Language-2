using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        public readonly object gameLock = new object();
        //private Border border;
        private Border border = new Border();
        private Paddle paddle1 = new Paddle(ConsoleKey.W, ConsoleKey.S, 1); // Assign keys for player 1
        private Paddle paddle2 = new Paddle(ConsoleKey.I, ConsoleKey.K, Console.WindowWidth - 2); // Assign keys for player 2
        private Scoreboard scoreboard = new Scoreboard(2); // Best of 5 game
        private Ball ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2, 1, 1); // Initial position and velocity of the ball
        private bool gameRunning;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Initialize game
            gameRunning = true;
        }

        public async Task Start()
        {
            // Clears the console
            Console.Clear();

            // Start handling input for both paddles asynchronously
            _ = Task.Run(paddle1.HandleInput);
            _ = Task.Run(paddle2.HandleInput);

            // Redraw the border
            border.Draw(0, 1);

            // Start the game loop
            while (gameRunning)
            {
                // Draw the scoreboard above the game area and centered
                scoreboard.Draw(scoreboard.X, scoreboard.Y);


                // Draw the paddles in their current positions
                // Int given is the x axis position of the paddle
                paddle1.Draw(paddle1.X, paddle1.Y);
                paddle2.Draw(paddle2.X, paddle2.Y);

                // Check for game end conditions
                if (scoreboard.Player1Wins())
                {
                    scoreboard.Win(1);
                    gameRunning = false;
                } 
                else if (scoreboard.Player2Wins())
                {
                    scoreboard.Win(2);
                    gameRunning = false;
                }

                // Introduce a small delay to control the game speed
                await Task.Delay(2);
            }
        }
        public async Task Ball()
        {
            while (gameRunning)
            {
                // Update and draw the ball
                ball.Move();

                // Check for collisions between the ball and the border
                ball.CheckPaddleCollision(paddle1);
                ball.CheckPaddleCollision(paddle2);
                ball.CheckBorderCollision(Console.WindowWidth, Console.WindowHeight, scoreboard);

                // Introduce a small delay to control the game speed
                await Task.Delay(50);
            }
        }

        public void AskAgain()
        {
            while (true)
            {
                //scoreboard.Win(winner);
                // Sets the cursor position to the line underneath the win message
                Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 1);
                Console.WriteLine("Do you wanna play again? Press enter");

                // Check the pressed key
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    // If key = enter, start the game again
                    // Starts the game
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
