﻿using System;

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
            this.AssetImage = new string[] { $"Player 1: {players[0].Score}  Player 2: {players[1].Score}" }; // Set the scoreboard with the new scores
        }

        public bool CheckForWinner(List<Player> Players) // Checks if there is a winner and returns true
        {
            foreach (Player Player in Players)
            {
                if (Player.Score >= Player.PointsToWin)
                {
                    Win(Player);
                    return true;
                }
            }
            return false;
        }

        public void Win(Player Player) // Displays the win message
        {
            string message = $"Player {Player.Id} wins the game!";
            Console.SetCursorPosition((Console.WindowWidth / 2) - (message.Length / 2), Console.WindowHeight / 2); // Sets the cursor at the middle of the screen with a offset so the message will be in the middle

            Console.Write(message);
        }
    }
}
