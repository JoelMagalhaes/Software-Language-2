using System;

namespace Pong
{
    public class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int velocityX;
        private int velocityY;

        public Ball(int x, int y, int velocityX, int velocityY)
        {
            X = x;
            Y = y;
            this.velocityX = velocityX;
            this.velocityY = velocityY;
        }


        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O"); // Assuming "O" represents the ball
        }

        public void Remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
        public void Move()
        {
            // Remove the ball
            Remove();

            // Set the new coordinates based on the velocity of the ball
            X += velocityX;
            Y += velocityY;

            // Draw the ball on the new position
            Draw();
        }

        public void Reset()
        {
            // Remove the ball
            Remove();

            // Change the ball coordinates to default
            // Default is the middle of the screen
            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight / 2;

            // Draw the ball on the default position
            Draw();
        }
        public void CheckBorderCollision(int maxWidth, int maxHeight, Scoreboard scoreboard)
        {
            // Check collision with left and right borders
            if (X <= 1)
            {
                velocityX = -velocityX; // Reverse the horizontal velocity
                Reset();
                scoreboard.IncrementPlayer2Score();
            } else if (X >= maxWidth - 2)
            {
                velocityX = -velocityX;
                Reset();
                scoreboard.IncrementPlayer1Score();
            }

            // Check collision with top border
            if (Y <= 2)
            {
                velocityY = Math.Abs(velocityY); // Ensure the vertical velocity is positive
            }

            // Check collision with bottom border
            if (Y >= maxHeight - 2)
            {
                velocityY = -Math.Abs(velocityY); // Ensure the vertical velocity is negative
            }
        }

        public void CheckPaddleCollision(Paddle paddle)
        {
            if (X == paddle.X && Y >= paddle.Y && Y <= paddle.Y + paddle.Length)
            {
                velocityX = -velocityX;
            }
        }
    }
}
