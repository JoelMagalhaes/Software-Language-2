using System;

namespace Pong
{
    public class Scoreboard : Asset
    {
        public Scoreboard()
        {
            this.X = Console.WindowWidth / 2 - 12;
            this.Y = 0;
        }

        public void Update(List<Player> players)
        {
            this.assetImage = new string[] { $"Player 1: {players[0].score}  Player 2: {players[1].score}" }; // Set the scoreboard with the new scores
        }

        public bool CheckForWinner(List<Player> players) // Checks if there is a winner and returns true
        {
            foreach (Player player in players)
            {
                if (player.score >= player.pointsToWin)
                {
                    Win(player);
                    return true;
                }
            }
            return false;
        }

        public void Win(Player player) // Displays the win message
        {
            this.messages = new string[] { $"Player {player.id} wins the game!" }; // Sets the message
            Message(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2); // Writes the message
        }
    }
}
