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

        public void Move()
        {
            X += velocityX;
            Y += velocityY;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O"); // Assuming "O" represents the ball
        }

        public void CheckBorderCollision(int maxWidth, int maxHeight)
        {
            // Check collision with left and right borders
            if (X <= 0 || X >= maxWidth - 2)
            {
                velocityX = -velocityX; // Reverse the horizontal velocity
            }

            // Check collision with top border
            if (Y <= 3)
            {
                velocityY = Math.Abs(velocityY); // Ensure the vertical velocity is positive
            }

            // Check collision with bottom border
            if (Y >= maxHeight - 4)
            {
                velocityY = -Math.Abs(velocityY); // Ensure the vertical velocity is negative
            }
        }
    }
}
