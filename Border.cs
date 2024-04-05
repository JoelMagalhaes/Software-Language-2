using System;

namespace Pong
{
    public class Border
    {

        public int Top { get; private set; }
        public int Bottom { get; private set; }
        public int Left { get; internal set; }
        public int Right { get; internal set; }

        public Border(int top, int bottom)
        {
            Top = top;
            Bottom = bottom;
        }

        // Draw the border on the console
        public void Draw(int width, int height)
        {
            Console.Clear();

            // Draw top and bottom borders
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, Top);
                Console.Write("+");
                Console.SetCursorPosition(x, Bottom);
                Console.Write("+");
            }

            // Draw left and right borders
            for (int y = Top + 1; y < Bottom; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("+");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("+");
            }
        }
    }
}
