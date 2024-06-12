using System;
using System.Collections.Generic;

namespace Pong
{
    public class Ball : Asset
    {
        private double _velocityX;
        private double _velocityY;
        private const double SpeedIncreaseStep = 0.2;
        private int _hitCount = 0;
        private const int HitsBeforeSpeedIncrease = 1;
        private double _positionX; 
        private double _positionY; 

        // Constructor with correct parameter types
        public Ball(double velocityX, double velocityY)
        {
            // Sets the ball's start location
            _positionX = Console.WindowWidth / 2;
            _positionY = Console.WindowHeight / 2;

            _velocityX = velocityX;
            _velocityY = velocityY;

            this.AssetImage = new string[] { "O" };
        }

        public void Move()
        {
            Remove(); // Remove the ball from the old location

            // Set the new coordinates based on the velocity of the ball
            _positionX += _velocityX;
            _positionY += _velocityY;

            // Update integer positions for rendering
            X = (int)_positionX;
            Y = (int)_positionY;

            Draw(); // Draw the ball in the new position
        }

        public void Reset()
        {
            Remove(); // Remove the ball from the old location

            // Change the ball coordinates to default
            // Default is the middle of the screen
            _positionX = Console.WindowWidth / 2;
            _positionY = Console.WindowHeight / 2;

            // Update integer positions for rendering
            X = (int)_positionX;
            Y = (int)_positionY;

            Draw(); // Draw the ball in the default position
        }

        public void CheckCollision(List<Player> players, List<Paddle> paddles)
        {
            bool isPaddleCollision = false; // Boolean for paddle collisions
            foreach (Paddle paddle in paddles) // Checks if the ball collides with a paddle and if so sets the isPaddleCollision to true
            {
                if (X == paddle.X && Y >= paddle.Y && Y <= paddle.Y + paddle.Length)
                {
                    isPaddleCollision = true;
                    break;
                }
            }

            if (isPaddleCollision) // If there is a paddle collision change the way the ball is going
            {
                _velocityX = -_velocityX;
                _hitCount++;
               
                if (_hitCount >= HitsBeforeSpeedIncrease)
                {
                    _velocityX += Math.Sign(_velocityX) * SpeedIncreaseStep;
                    _velocityY += Math.Sign(_velocityY) * SpeedIncreaseStep;
                    _hitCount = 0; // Reset the hit counter
                }
            }
            else // If there is no paddle collision, check for border x collisions
            {
                if (X <= 1) // Check collision with left border
                {
                    _velocityX = -_velocityX; // Reverse the horizontal velocity
                    Reset();
                    players[1].IncrementScore(); // Increments the score of player 2
                }
                else if (X >= Console.WindowWidth - 2) // Check collision with right border
                {
                    _velocityX = -_velocityX; // Reverse the horizontal velocity
                    Reset();
                    players[0].IncrementScore(); // Increments the score of player 1
                }
            }

            if (Y <= 2) // Check collision with top border
            {
                _velocityY = -_velocityY; // Ensure the vertical velocity is positive
                _positionY = 2; // Correct position
            }
            else if (Y >= Console.WindowHeight - 2) // Check collision with bottom border
            {
                _velocityY = -_velocityY; // Ensure the vertical velocity is negative
                _positionY = Console.WindowHeight - 2; // Correct position
            }
        }
    }
}
