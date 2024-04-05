using System;

namespace Pong
{
    public class Scoreboard
    {
        private int player1Score;
        private int player2Score;

        public Scoreboard(int pointsToWin)
        {
            player1Score = 0;
            player2Score = 0;
        }

        public void IncrementPlayer1Score()
        {
            player1Score++;
        }

        public void IncrementPlayer2Score()
        {
            player2Score++;
        }

        public bool Player1Wins()
        {
            return player1Score >= 5; // Assuming best of 5 game
        }

        public bool Player2Wins()
        {
            return player2Score >= 5; // Assuming best of 5 game
        }

        public void Draw(int gameWidth)
        {
            // Calculate scoreboard position to center it within the border
            int scoreboardX = (gameWidth - 80) / 2; // Adjusted to center the scoreboard within the border
            int scoreboardY = 0; // Above the top border

            // Set cursor position for drawing scoreboard
            Console.SetCursorPosition(scoreboardX, scoreboardY);

            // Display the scoreboard
            Console.Write($"Player 1: {player1Score}  Player 2: {player2Score}");
        }

        internal void Draw(object value)
        {
            throw new NotImplementedException();
        }
    }
}
