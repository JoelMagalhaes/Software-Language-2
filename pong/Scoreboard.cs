using System;

namespace Pong
{
    public class Scoreboard : Asset
    {
        private int p1; // Score of player 1
        private int p2; // Score of player 2
        private readonly int pointsToWin;

        public Scoreboard(int pointsToWin)
        {
            p1 = 0;
            p2 = 0;
            this.pointsToWin = pointsToWin; // A player has to get this many points to win the game

            this.X = Console.WindowWidth / 2 - 12;
            this.Y = 0;

            UpdateScoreboard();
        }

        public void IncrementPlayerScore(int player) // Increments the score of the given player
        {
            switch (player)
            {
                case 1:
                    this.p1++;
                    break;
                case 2:
                    this.p2++;
                    break;
                default:
                    break;
            }

            UpdateScoreboard();
        }

        private void UpdateScoreboard()
        {
            this.assetImage = new string[] { $"Player 1: {p1}  Player 2: {p2}" }; // Set the scoreboard with the new scores
        }

        public bool CheckForWinner() // Checks if there is a winner and returns true
        {
            if (p1 >= pointsToWin) // You win if your score is equal to the points to win
            {
                Win(1);
                return true;
            }
            else if (p2 >= pointsToWin) // You win if your score is equal to the points to win
            {
                Win(2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Win(int player) // Displays the win message
        {
            this.messages = new string[] { $"Player {player} wins the game!" }; // Sets the message
            Message(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2); // Writes the message
        }
    }
}
