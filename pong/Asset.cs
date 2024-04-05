using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Asset
    {
        private readonly static object gameLock = new object();
        public string[] assetImage = {""};
        public int X;
        public int Y;

        public void Draw(String input)
        {
            Console.WriteLine(input);
        }

        public void Draw(int x = 0, int y = 0)
        {
            lock (gameLock)
            {
                Remove();

                foreach (string row in assetImage)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write(row);
                }
            }
        }

        public void Remove()
        {
            lock (gameLock)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');
            }
        }
    }
}
