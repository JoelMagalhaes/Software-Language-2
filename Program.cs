using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{ 
    class Program
    {

        // Define game parameters
        public static int player1Score = 0; // Player 1's score
        public static int player2Score = 0; // Player 2's score
        public static int pointsToWin = 5; // Points needed to win the game

        static async Task Main()
        {
            // Hide cursor and clear console
            Console.CursorVisible = false;
            Console.Clear();

            Game game = new Game();
            await game.Start();


            // Start separate tasks for input handling of each player
            //Task taskPlayer1Input = Task.Run(() => PlayerInput(ConsoleKey.W, ConsoleKey.S, () => paddle1Y -= paddleSpeed, () => paddle1Y += paddleSpeed, () => paddle1Y, borderHeight, gameHeight - paddleLength));
            //Task taskPlayer2Input = Task.Run(() => PlayerInput(ConsoleKey.I, ConsoleKey.K, () => paddle2Y -= paddleSpeed, () => paddle2Y += paddleSpeed, () => paddle2Y, borderHeight, gameHeight - paddleLength));
        }

        // Function to handle player input asynchronously
        static async Task PlayerInput(ConsoleKey upKey, ConsoleKey downKey, Action moveUp, Action moveDown, Func<int> getPaddleY, int topBoundary, int bottomBoundary)
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == upKey && getPaddleY() > topBoundary)
                    {
                        moveUp();
                    }
                    if (key.Key == downKey && getPaddleY() < bottomBoundary)
                    {
                        moveDown();
                    }
                }
                await Task.Delay(50); // Decreased delay for faster response
            }
        }
        // Function to draw the scoreboard
        static void DrawScoreboard(int gameWidth, int player1Score, int player2Score)
        {
            // Calculate scoreboard position
            int scoreboardX = Math.Max(0, gameWidth / 2 - 12); // Centered above the game area
            int scoreboardY = 0; // First line of the console window

            // Draw scoreboard
            Console.SetCursorPosition(scoreboardX, scoreboardY);
            Console.Write($"Player 1: {player1Score}  Player 2: {player2Score}");
        }

        

        // Function to end the game
        static void EndGame(string winner)
        {
            // Clear only the area needed for the message
            int messageWidth = winner.Length + 12; // Length of "Game over! " plus length of the winner's name
            int messageX = (Console.WindowWidth - messageWidth) / 2;
            int messageY = Console.WindowHeight / 2;

            Console.SetCursorPosition(messageX, messageY);
            Console.Write($"Game over! {winner} wins the game!");

            // Wait for a key press before exiting
            Console.WriteLine("\nPress any key to exit...");
            _ = Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

