using System;

namespace Pong
{
    public class Scoreboard : Asset
    {
        private int player1Score;
        private int player2Score;
        private readonly int pointsToWin;

        public Scoreboard(int pointsToWin)
        {
            player1Score = 0;
            player2Score = 0;
            this.pointsToWin = pointsToWin;

            this.X = Console.WindowWidth / 2 - 12;
            this.Y = 0;
            this.assetImage = new String[] { $"Player 1: {player1Score}  Player 2: {player2Score}" };
        }

        public void IncrementPlayer1Score()
        {
            player1Score++;
            this.assetImage = new string[] { $"Player 1: {player1Score}  Player 2: {player2Score}" }; // Sets the assetImage again to update the score
        }

        public void IncrementPlayer2Score()
        {
            player2Score++;
            this.assetImage = new string[] { $"Player 1: {player1Score}  Player 2: {player2Score}" }; // Sets the assetImage again to update the score
        }

        public bool Player1Wins()
        {
            return player1Score >= pointsToWin; // returns true if the player has the points to win the game
        }

        public bool Player2Wins()
        {
            return player2Score >= pointsToWin; // returns true if the player has the points to win the game
        }

        public void Win(int player)
        {
            this.assetImage = new string[] { $"Player {player} wins the game!" };
            Draw(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2);
        }
    }
}
