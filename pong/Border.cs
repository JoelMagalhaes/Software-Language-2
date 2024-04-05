using System;

namespace Pong
{
    public class Border : Asset
    {
        public string tb = ""; // Initialize with an empty string
        public string lr = ""; // Initialize with an empty string

        public Border()
        {
            this.X = 0;
            this.Y = 1;

            for (int i = 0; i < Console.WindowWidth; i++) { tb += "+"; }
            for (int i = 0; i < Console.WindowWidth - 2; i++) { lr += " "; }
            lr = "+" + lr + "+"; // Set lr correctly

            this.assetImage = new String[Console.WindowHeight]; // Initialize the array with correct size

            this.assetImage[0] = tb; // Assign the top border
            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                this.assetImage[i] = lr; // Assign the side borders
            }
            this.assetImage[Console.WindowHeight - 2] = tb; // Assign the bottom border
        }
    }
}
