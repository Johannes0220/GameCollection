namespace GameCollection.Games.TicTacToe;

public class TicTacToeView
{
    private readonly int _delayMainMenu = 3000;

    public void PrintBoard(TicTacToe ticTacToe)
    {
        Console.Clear();
        Console.WriteLine("╔===========╗");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("║ " + ticTacToe.board[i * 3] + " ║ " + ticTacToe.board[i * 3 + 1] + " ║ " + ticTacToe.board[i * 3 + 2] + " ║");
            if (i == 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("║===========║");
            }
        }
        Console.WriteLine("╚===========╝");
    }

    public int GetPlayerMove(char player)
    {
        while (true)
        {
            try
            {
                Console.Write($"Player {player}, enter your move (0-8): ");
                int move = int.Parse(Console.ReadLine());
                if (move >= 0 && move <= 8)
                {
                    return move;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 8.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public void DisplayInvalidMove()
    {
        Console.WriteLine("Invalid move. Try again.");
    }

    public void DisplayWinner(char winner)
    {
        Console.CursorVisible = false;
        Console.WriteLine($"Player {winner} wins!");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
        Console.CursorVisible = true;
    }

    public void DisplayTie()
    {
        Console.CursorVisible = false;
        Console.WriteLine("It's a tie!");
        Console.WriteLine("You will be redirected to the game selection in 3 seconds");
        Thread.Sleep(_delayMainMenu);
        Console.Clear();
        Console.CursorVisible = true;
    }
}
