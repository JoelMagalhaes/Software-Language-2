using System;

namespace Pong
{
    public class Border
    {
        // Draw the border on the console
        public void Draw(int width, int height)
        {
            Console.Clear();

            // Draw top and bottom borders
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 1);
                Console.Write("+");
                Console.SetCursorPosition(x, height -1);
                Console.Write("+");
            }

            // Draw left and right borders
            for (int y = 1; y < height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("+");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("+");
            }
        }
    }
}
