using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Paddle
    {
        // Define properties for the paddle
        public int X { get; set; }
        public int Y { get; private set; }
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int TopBoundary { get; private set; }
        public int BottomBoundary { get; private set; }

        // Input keys for controlling the paddle
        private ConsoleKey upKey;
        private ConsoleKey downKey;

        public Paddle(ConsoleKey upKey, ConsoleKey downKey, int x)
        {
            X = x;
            Y = 12; // Set the initial Y position
            Length = 5; // Default length
            Width = 5; // Default width
            TopBoundary = 2; // Default top boundary
            BottomBoundary = Console.WindowHeight - 1; // Default bottom boundary

            this.upKey = upKey;
            this.downKey = downKey;
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

        // Function to draw the paddle
        public void Draw()
        {
            // Removes the paddle
            Remove();

            // Draws the paddle on the new position
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("|");
            }
        }
        
        public void Remove()
        {
            for (int i = 0; i < Length + 2; i++)
            {
                Console.SetCursorPosition(X, Y - 1 + i);
                Console.Write(' ');
            }
        }

        // Function to handle player input asynchronously
        public async Task HandleInput()
        {
            while (true)
            {
                if (await Task.Run(() => Console.KeyAvailable))
                {
                    ConsoleKeyInfo key = await Task.Run(() => Console.ReadKey(true));
                    if (key.Key == upKey && Y > TopBoundary)
                    {
                        MoveUp();
                    }
                    else if (key.Key == downKey && Y + Length < BottomBoundary)
                    {
                        MoveDown();
                    }
                }
                await Task.Delay(10); // Adjust delay as needed for smoother input handling
            }
        }
    }
}
