using System;

namespace Pong
{
    public class Ball : Asset
    {
        private int velocityX;
        private int velocityY;

        public Ball(int velocityX, int velocityY)
        {
            // Sets the balls start location
            this.X = Console.WindowWidth / 2;
            this.Y = Console.WindowHeight / 2;

            this.velocityX = velocityX;
            this.velocityY = velocityY;

            this.assetImage = new String[] { "O" };
        }

        public void Move()
        {
            Remove(); // Remove the ball on the old location

            // Set the new coordinates based on the velocity of the ball
            X += velocityX;
            Y += velocityY;

            Draw(); // Draw the ball on the new position
        }

        public void Reset()
        {
            Remove(); // Remove the ball on the old location

            // Change the ball coordinates to default
            // Default is the middle of the screen
            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight / 2;

            Draw(); // Draw the ball on the default position
        }

        public void CheckCollision(Scoreboard scoreboard, List<Paddle> paddles)
        {
            bool isPaddleCollision = false; // Boolean for paddle collisions
            foreach (Paddle paddle in paddles) // Checks if the ball collides with a paddle and if so sets the isPaddleCollision to true
            {
                if (X == paddle.X && Y >= paddle.Y && Y <= paddle.Y + paddle.Length) { isPaddleCollision = true; break; }
            }

            if (isPaddleCollision) // If there is a paddle collision change the way the ball is going
            {
                velocityX = -velocityX;
            }
            else // If there is no padlle collision check for border x collisions
            {
                if (X <= 1) // Check collision with left border
                {
                    velocityX = -velocityX; // Reverse the horizontal velocity
                    Reset();
                    scoreboard.IncrementPlayerScore(2); // Increments the score of player 2
                } 
                else if (X >= Console.WindowWidth - 2) // Check collision with right border
                {
                    velocityX = -velocityX; // Reverse the horizontal velocity
                    Reset();
                    scoreboard.IncrementPlayerScore(1); // Increments the score of player 1
                }
            }

            if (Y <= 2) // Check collision with top border
            {
                velocityY = -velocityY; // Ensure the vertical velocity is positive
            }          
            else if (Y >= Console.WindowHeight - 2) // Check collision with bottom border
            {
                velocityY = -velocityY; // Ensure the vertical velocity is negative
            }
        }
    }
}