using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Paddle : Asset
    {
        // Define properties for the paddle
        public int Length { get; private set; }
        public int TopBoundary { get; private set; }
        public int BottomBoundary { get; private set; }

        // Input keys for controlling the paddle
        public ConsoleKey upKey;
        public ConsoleKey downKey;

        public Paddle(ConsoleKey upKey, ConsoleKey downKey, int x)
        {
            this.X = x; // The x position the paddle will be in
            this.Y = 12; // Set the initial Y position

            Length = 5; // Length of the paddle
            TopBoundary = 2; // Top boundary
            BottomBoundary = Console.WindowHeight - 1; // Default bottom boundary

            this.upKey = upKey; // The key which the player uses to move the paddle up
            this.downKey = downKey; // The key which the player uses to move the paddle down

            // Array with the paddle
            this.assetImage = new string[Length];
            for (int i = 0; i < Length; i++) { this.assetImage[i] = "|"; } // Makes the array with the paddle character the length of the paddle
        }

        public void Move(string way)
        {
            this.Remove(); // Removes the paddle
            switch (way)
            {
                case "up":
                    if (Y > TopBoundary) { Y--; } // Moves the paddle up if it is lower than the top
                    break;
                case "down":
                    if (Y + Length /* Y coordinate + the length of the paddle */ < BottomBoundary) { Y++; } // Moves the paddle down if it is higher than the bottom of the screen
                    break;
                default:
                    throw new ArgumentException("Invalid direction. Expected 'up' or 'down'.", nameof(way));
            }
            
            this.Draw(); // Draws the paddle in the new location
        }
    }
}
