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
        private ConsoleKey upKey;
        private ConsoleKey downKey;

        public Paddle(ConsoleKey upKey, ConsoleKey downKey, int x)
        {
            this.X = x;
            this.Y = 12; // Set the initial Y position

            Length = 5; // Default length
            TopBoundary = 2; // Default top boundary
            BottomBoundary = Console.WindowHeight - 1; // Default bottom boundary

            this.upKey = upKey;
            this.downKey = downKey;
            
            // Array with the paddle
            this.assetImage = new string[Length];
            // Makes the array with the paddle character the length of the paddle
            for (int i = 0; i < Length; i++) { this.assetImage[i] = "|"; }
        }

        // Function to move the paddle up
        public void MoveUp()
        {
            if (Y > TopBoundary)
            {
                Y--;
            }
        }

        // Function to move the paddle down
        public void MoveDown()
        {
            if (Y + Length < BottomBoundary)
            {
                Y++;
            }
        }

        // Function to handle player input asynchronously
        public void HandleInput()
        {
            while (true)
            {
                //await Task.Run(() =>
                //{
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == upKey && Y > TopBoundary)
                    {
                        MoveUp();
                    }
                    else if (key == downKey && Y + Length < BottomBoundary)
                    {
                        MoveDown();
                    }
                //});
            }
        }
    }
}
