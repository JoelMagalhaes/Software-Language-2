using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Asset
    {
        private readonly static object s_gameLock = new object(); // Makes a lock so you cant draw two things at once
        public string[] AssetImage = {""}; // The array for the to be drawn image
        public int X; // The X coordinate on the screen
        public int Y; // The Y coordinate on the screen 

        public string[] Messages = { "" }; // The array for the messages

        public void Draw(String Input)
        {
            Console.WriteLine(Input);
        }

        public void Draw()
        {
            int X = this.X;
            int Y = this.Y;

            lock (s_gameLock)
            {
                foreach (string Row in AssetImage) // Foreach loop to draw what is in the assetImage array
                {
                    try
                    {
                        // Check if coordinates are within range of the screen
                        if (Y >= 0 && Y < Console.WindowHeight - 1)
                        {
                            Console.SetCursorPosition(X, Y); // Set cursor position
                            Console.WriteLine(Row); // Writes the row onto the screen
                            Y++;
                        }
                        else
                        {
                            // On the last row, dont change the cursor position and write the last row
                            Console.Write(Row);
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // If there is an error with writing to the screen, display it
                        Console.WriteLine($"Error: {ex.Message}");
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void Remove() // Removes the old image
        {
            int X = this.X;
            int Y = this.Y;

            lock (s_gameLock)
            { 

                foreach (string row in AssetImage) // Removes each part of a 1 wide asset
                {
                    Console.SetCursorPosition(X, Y); // Set the cursor to the old position
                    Console.Write(' '); // Write a space to clear the displayed character
                    Y++; // Adds to the y coordinate
                }
            }
        }   
    }
}
