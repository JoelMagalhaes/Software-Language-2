using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Asset
    {
        //private readonly static object gameLock = new object(); // Makes a lock so you cant draw two things at once
        public string[] assetImage = {""}; // The array for the to be drawn image
        public int X; // The X coordinate on the screen
        public int Y; // The Y coordinate on the screen 

        public string[] messages = { "" }; // The array for the messages

        public void Draw(String input)
        {
            Console.WriteLine(input);
        }

        public void Draw()
        {
            int x = X;
            int y = Y;

            foreach (string row in assetImage) // Foreach loop to draw what is in the assetImage array
            {
                try
                {
                    // Check if coordinates are within range of the screen
                    if (y >= 0 && y < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(x, y); // Set cursor position
                        Console.WriteLine(row); // Writes the row onto the screen
                        y++;
                    }
                    else
                    {
                        // On the last row, dont change the cursor position and write the last row
                        Console.WriteLine(row);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // If there is an error with writing to the screen, display it
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void Remove() // Removes the old image
        {
            Console.SetCursorPosition(X, Y); // Set the cursor to the old position
            Console.Write(' '); // Write a space to clear the displayed character
        }   

        public void Message() // Puts the message on the middle of the screen
        {
            // These are the coordinates of the middle of the screen
            int windowWidthHalf = Console.WindowWidth / 2;
            int windowHeightHalf = Console.WindowHeight / 2;

            int offset = - (messages.Length / 2); // This is the offset from the middle on the y axis

            foreach (string s in messages)
            {
                Console.SetCursorPosition(windowWidthHalf - (s.Length / 2) /* Takes half the length of s from the x half so the message is in the middle of the screen  */ ,
                                            windowHeightHalf + offset++ /* The offset is used so the lines will be roughly in the middle of the screen */); // Set the cursor position for the line
                Console.WriteLine(s);
            }
        }

        public void Message(int x, int y) // Puts the first message on the specified line and the lines underneath
        {
            foreach (string s in messages)
            {
                Console.SetCursorPosition(x, y++); // Sets the cursor on the specified place
                Console.WriteLine(s); // Writes the message
            }
        }
    }
}
