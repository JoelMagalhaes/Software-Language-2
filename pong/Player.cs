using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Player
    {
        public readonly int pointsToWin = 5;
        public int id;
        public int score {  get; private set; }

        public Player(int id)
        {
            this.id = id;
        }
        public void IncrementScore()
        {
            score++;
        }
    }
}
