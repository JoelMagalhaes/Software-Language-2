using System;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        // Sets all the game assets into variables
        private Border _border = new Border();
        private List<Paddle> _paddles = new List<Paddle>() // List with the 2 paddles
        {
            new Paddle( ConsoleKey.W, ConsoleKey.S, 1 ),
            new Paddle(ConsoleKey.I, ConsoleKey.K, Console.WindowWidth - 2)
        };
        private List<Player> _players = new List<Player>()
        {
            new Player(1),
            new Player(2),
        };
        private Scoreboard _scoreboard = new Scoreboard();
        private Ball _ball = new Ball(1, 1); // Initial position and velocity of the ball
        private bool _gameRunning;

        public Game()
        {
            _gameRunning = true; // Starts the game
        }

        public async Task Start()
        {
            Console.Clear(); // Clears the console

            // Draws the assets onto the screen
            _border.Draw(); // Draw the border
            _ball.Draw();
            foreach (Paddle Paddle in _paddles) { Paddle.Draw(); }

            // Start the game loop
            while (_gameRunning)
            {
                if (Console.KeyAvailable) // If there is a key pressed, check if it is to move a paddle and then move a paddle. This is being done in this function so you dont have to press the key twice
                {
                    ConsoleKey Key = Console.ReadKey(true).Key; // Puts the pressed key into the variable key

                    foreach (Paddle Paddle in _paddles)
                    {
                        if (Key == Paddle.UpKey && Paddle.Y > Paddle.TopBoundary) // Checks if it is the paddle upKey and if paddle is not on the top of the screen
                        {
                            Paddle.Move(Paddle.DirectionType.up); // Move paddle up
                        }
                        if (Key == Paddle.DownKey && Paddle.Y + Paddle.Length < Paddle.BottomBoundary) // Checks if it is the paddle downKey and if paddle is not on the bottom of the screen
                        {
                            Paddle.Move(Paddle.DirectionType.down); // Move paddle down
                        }
                    }
                }

                // Draw the scoreboard above the game area and centered
                _scoreboard.Update(_players);
                _scoreboard.Draw();

                // Check for game end conditions
                if (_scoreboard.CheckForWinner(_players)) { _gameRunning = false; } // If someone won, stop the games

                await Task.Delay(2); // Task delay to control the speed
            }
        }
        public async Task Ball() // This task makes the ball run seperate from the rest of the game so it wont interupt the moving of the paddles
        {
            while (_gameRunning)
            {
                _ball.Move(); // Update and draw the 
                _ball.CheckCollision(_players, _paddles); // Check for collisions between the ball and the border or paddles
                _ball.Draw(); // Draw the ball in the new position
                await Task.Delay(_ball.Speed); // Task delay to control the speed
            }
        }

        public void AskAgain()
        {
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 1); // Writes the message on the specified line
                Console.Write("Do you wanna play again? Press enter"); // Sets the message

                ConsoleKey Key = Console.ReadKey(true).Key; // Check the pressed key
                if (Key == ConsoleKey.Enter)
                {
                    // If key = enter, start the game again
                    Game game = new Game();
                    Task.WaitAny(game.Start(), game.Ball());
                }
                else
                {
                    // If key is not enter, exit
                    Environment.Exit(0);
                }
            }
        }
    }
}
