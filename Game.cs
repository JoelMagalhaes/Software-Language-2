using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        private Border border;
        private Paddle paddle1;
        private Paddle paddle2;
        private Ball ball;
        private bool gameRunning;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Initialize game objects here
            border = new Border(1, Console.WindowHeight - 1); // Example initialization, adjust as necessary
            paddle1 = new Paddle(); // Example initialization, adjust as necessary
            paddle2 = new Paddle(); // Example initialization, adjust as necessary
            ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2);
            gameRunning = true;
        }

        public async Task Start()
        {
            border.Draw(Console.WindowWidth, Console.WindowHeight); // Correctly call Draw method
            paddle1.Draw(1); // Example draw method, adjust as necessary
            paddle2.Draw(Console.WindowWidth - 2); // Example draw method, adjust as necessary
            while (gameRunning)
            {
                // Clear ball's previous position
                ball.Clear();

                // Move the ball
                ball.Move(border,Console.WindowWidth, Console.WindowHeight);


                // Redraw the ball at its new position
                ball.Draw();

                // Game loop logic here (paddle movement, collision detection, scoring, etc.)

                await Task.Delay(1000); // This sets the game's update rate; adjust as needed for your game's responsiveness
            }
        }
        // Other game methods here (e.g., methods for moving paddles, updating ball position, checking for scores, etc.)
    }
}
