using System;

namespace Pong
{
    public class Border : Asset
    {
        public string Tb = ""; // String for the top and bottom of the border
        public string Lr = ""; // String for the left and right sides of the border

        public Border()
        {
            // Setting the default start location of the border
            this.X = 0;
            this.Y = 1;

            for (int i = 0; i < Console.WindowWidth; i++) { Tb += "+"; } // Makes a row with '+' for the entire screen width
            for (int i = 0; i < Console.WindowWidth - 2; i++) { Lr += " "; } // Makes a string that start with '+' and end with '+'. And makes it the width of the screen
            Lr = "+" + Lr + "+"; // Set lr correctly

            this.AssetImage = new String[Console.WindowHeight]; // Initialize the array with correct size

            this.AssetImage[0] = Tb; // Assign the top border
            for (int i = 1; i < Console.WindowHeight - 2; i++) // Runs for each row of the border after the top border
            {
                this.AssetImage[i] = Lr; // Assign the side borders
            }
            this.AssetImage[Console.WindowHeight - 2] = Tb; // Assign the bottom border
        }
    }
}
