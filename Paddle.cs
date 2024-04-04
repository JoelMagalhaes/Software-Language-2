using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Paddle
    {
        // Define game parameters
        public int Y { get; private set; }
        public int Length { get; private set; } 
        public int Width { get; private set; }
        public int Speed { get; private set; }

        public Paddle()
        {
            Y = 12;      // Set the initial Y position
            Length = 5; // Default length
            Width = 5;  // Default width
            Speed = 1;  // Default speed
        }
        public void MoveUp()
        {
            Y -= Speed;
        }
        public void MoveDown()
        {
            Y += Speed;
        }
        // Function to draw a paddle
        public void Draw(int x)
        {
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(x, Y + i); // Adjusted position to leave space for the border
                Console.Write("|");
            }
        }
        // Method to check if a position (x, y) hits the paddle
        public bool Hit(int x, int y)
        {
            // Check if the given position (x, y) is within the paddle's range
            return x == Y && y >= Y && y < Y + Length;
        }
    }
}
