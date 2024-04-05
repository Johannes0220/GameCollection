namespace GameCollection.Games.TicTacToe;

public class TicTacToeView
{
    public void PrintBoard(TicTacToe ticTacToe)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("| " + ticTacToe.board[i * 3] + " | " + ticTacToe.board[i * 3 + 1] + " | " + ticTacToe.board[i * 3 + 2] + " |");
        }
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
}
