using System;

class Program
{
    static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1; // Current player (1 or 2)
    static int choice; // User's choice/input
    static int flag = 0; // Flag to determine game status (1 for a win, -1 for a draw, 0 for ongoing)
    static int scorePlayer1 = 0; // Score for Player 1
    static int scorePlayer2 = 0; // Score for Player 2

    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");
            Console.WriteLine("Score:\nPlayer 1: {0}\nPlayer 2: {1}", scorePlayer1, scorePlayer2);

            // Display whose turn it is
            if (player % 2 == 0)
            {
                Console.WriteLine("Turn player 2");
            }
            else
            {
                Console.WriteLine("Turn player 1");
            }
            Console.WriteLine("\n");
            Board();

            string line = Console.ReadLine();
            bool result = Int32.TryParse(line, out choice);

            // Input validation
            if (!result)
            {
                Console.WriteLine("Please enter a valid number between 1 and 9.");
                Console.ReadLine();
                continue;
            }

            if (choice < 1 || choice > 9)
            {
                Console.WriteLine($"There is no cell \"{choice}\" on the field.");
                Console.ReadLine();
                continue;
            }

            // Check if the chosen cell is already taken
            if (arr[choice] != 'X' && arr[choice] != 'O')
            {
                // Update the board with the player's move
                if (player % 2 == 0)
                {
                    arr[choice] = 'O';
                    player++;
                }
                else
                {
                    arr[choice] = 'X';
                    player++;
                }
            }
            else
            {
                Console.WriteLine($"Cell \"{choice}\" is already set.");
                Console.ReadLine();
            }

            // Check for a win or draw
            flag = CheckWin();
        }
        while (flag != 1 && flag != -1);

        Console.Clear();
        Board();

        if (flag == 1)
        {
            Console.WriteLine("Player {0} has won", (player % 2) + 1);

            // Update scores based on the winning player
            if ((player % 2) + 1 == 1)
            {
                scorePlayer1++;
            }
            else
            {
                scorePlayer2++;
            }
        }
        else
        {
            Console.WriteLine("Draw");
        }
        Console.ReadLine();

        // Reset the game state
        arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        player = 1;
        flag = 0;
    }

    // Method to display the Tic Tac Toe board
    private static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
        Console.WriteLine("     |     |      ");
    }

    // Method to check for a win or draw
    private static int CheckWin()
    {
        // Horizontal Winning Condition
        if (arr[1] == arr[2] && arr[2] == arr[3])
        {
            return 1;
        }
        else if (arr[4] == arr[5] && arr[5] == arr[6])
        {
            return 1;
        }
        else if (arr[6] == arr[7] && arr[7] == arr[8])
        {
            return 1;
        }

        // Vertical Winning Condition
        else if (arr[1] == arr[4] && arr[4] == arr[7])
        {
            return 1;
        }
        else if (arr[2] == arr[5] && arr[5] == arr[8])
        {
            return 1;
        }
        else if (arr[3] == arr[6] && arr[6] == arr[9])
        {
            return 1;
        }

        // Diagonal Winning Condition
        else if (arr[1] == arr[5] && arr[5] == arr[9])
        {
            return 1;
        }
        else if (arr[3] == arr[5] && arr[5] == arr[7])
        {
            return 1;
        }

        // Checking For Draw
        else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
        {
            return -1;
        }

        // Game still ongoing
        else
        {
            return 0;
        }
    }
}
