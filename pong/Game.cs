using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        //private Border border;
        private Border border = new Border();
        private Paddle paddle1 = new Paddle(ConsoleKey.W, ConsoleKey.S, 1); // Assign keys for player 1
        private Paddle paddle2 = new Paddle(ConsoleKey.I, ConsoleKey.K, Console.WindowWidth - 2); // Assign keys for player 2
        private Scoreboard scoreboard = new Scoreboard(5); // Best of 5 game
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
            Task paddle1InputTask = paddle1.HandleInput();
            Task paddle2InputTask = paddle2.HandleInput();

            // Redraw the border
            border.Draw(Console.WindowWidth, Console.WindowHeight);

            // Start the game loop
            while (gameRunning)
            {
                // Draw the scoreboard above the game area and centered
                scoreboard.Draw(Console.WindowWidth);


                // Draw the paddles in their current positions
                // Int given is the x axis position of the paddle
                paddle1.Draw();
                paddle2.Draw();

                // Update and draw the ball
                ball.Move();

                // Check for collisions between the ball and the border
                ball.CheckPaddleCollision(paddle1);
                ball.CheckPaddleCollision(paddle2);
                ball.CheckBorderCollision(Console.WindowWidth, Console.WindowHeight, scoreboard);

                // Check for game end conditions
                if (scoreboard.Player1Wins() || scoreboard.Player2Wins())
                {
                    gameRunning = false;
                }

                // Introduce a small delay to control the game speed
                await Task.Delay(2);
            }

            scoreboard.Draw(Console.WindowWidth);

            Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2);
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
    }
}
