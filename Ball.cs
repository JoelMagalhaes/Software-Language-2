namespace Pong
{
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public Ball(int x, int y)
        {
            X = x;
            Y = y;
            VelocityX = 1; // Starting X velocity
            VelocityY = 1; // Starting Y velocity
        }

        // Move the ball based on its velocity
        public void Move(Border border, int gameWidth, int gameHeight)
        {
            // Move the ball
            X += VelocityX;
            Y += VelocityY;

            // Check for collisions with top and bottom borders, and invert Y velocity if necessary
            if (Y <= border.Top + 1 || Y >= gameHeight - border.Bottom - 1)
            {
                VelocityY = -VelocityY;
            }


            // Check for collisions with side borders
            if (X <= border.Left || X >= gameWidth - border.Right - 1)
            {
                VelocityX = -VelocityX; // Invert X velocity
            }
        }


        // Draw the ball on the console
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
        }

        // Clear the ball from its current position on the console
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
