using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Player
    {
        public readonly int PointsToWin = 5;
        public int Id;
        public int Score {  get; private set; }

        public Player(int id)
        {
            this.Id = id;
        }
        public void IncrementScore()
        {
            Score++;
        }
    }
}
