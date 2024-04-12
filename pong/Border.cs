using System;

namespace Pong
{
    public class Border : Asset
    {
        public string tb = ""; // String for the top and bottom of the border
        public string lr = ""; // String for the left and right sides of the border

        public Border()
        {
            // Setting the default start location of the border
            this.X = 0;
            this.Y = 1;

            for (int i = 0; i < Console.WindowWidth; i++) { tb += "+"; } // Makes a row with '+' for the entire screen width
            for (int i = 0; i < Console.WindowWidth - 2; i++) { lr += " "; } // Makes a string that start with '+' and end with '+'. And makes it the width of the screen
            lr = "+" + lr + "+"; // Set lr correctly

            this.assetImage = new String[Console.WindowHeight]; // Initialize the array with correct size

            this.assetImage[0] = tb; // Assign the top border
            for (int i = 1; i < Console.WindowHeight - 1; i++) // Runs for each row of the border after the top border
            {
                this.assetImage[i] = lr; // Assign the side borders
            }
            this.assetImage[Console.WindowHeight - 1] = tb; // Assign the bottom border
        }
    }
}
