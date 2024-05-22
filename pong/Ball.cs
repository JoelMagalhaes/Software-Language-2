using System;

namespace Pong
{
    public class Ball : Asset
    {
        private int _velocityX;
        private int _velocityY;

        public Ball(int velocityX, int velocityY)
        {
            // Sets the balls start location
            this.X = Console.WindowWidth / 2;
            this.Y = Console.WindowHeight / 2;

            this._velocityX = velocityX;
            this._velocityY = velocityY;

            this.AssetImage = new String[] { "O" };
        }

        public void Move()
        {
            Remove(); // Remove the ball on the old location

            // Set the new coordinates based on the velocity of the ball
            X += _velocityX;
            Y += _velocityY;

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

        public void CheckCollision(List<Player> Players, List<Paddle> Paddles)
        {
            bool IsPaddleCollision = false; // Boolean for paddle collisions
            foreach (Paddle Paddle in Paddles) // Checks if the ball collides with a paddle and if so sets the isPaddleCollision to true
            {
                if (X == Paddle.X && Y >= Paddle.Y && Y <= Paddle.Y + Paddle.Length) { IsPaddleCollision = true; break; }
            }

            if (IsPaddleCollision) // If there is a paddle collision change the way the ball is going
            {
                _velocityX = -_velocityX;
            }
            else // If there is no padlle collision check for border x collisions
            {
                if (X <= 1) // Check collision with left border
                {
                    _velocityX = -_velocityX; // Reverse the horizontal velocity
                    Reset();
                    Players[1].IncrementScore(); // Increments the score of player 2
                } 
                else if (X >= Console.WindowWidth - 2) // Check collision with right border
                {
                    _velocityX = -_velocityX; // Reverse the horizontal velocity
                    Reset();
                    Players[0].IncrementScore(); // Increments the score of player 1
                }
            }

            if (Y <= 2) // Check collision with top border
            {
                _velocityY = -_velocityY; // Ensure the vertical velocity is positive
            }          
            else if (Y >= Console.WindowHeight - 2) // Check collision with bottom border
            {
                _velocityY = -_velocityY; // Ensure the vertical velocity is negative
            }
        }
    }
}