using System;
public static class HumanPlayer
{
    public static bool MakeMove(Board board)
    {
        int row1, col1, row2, col2;
        char card1, card2;

        // Flip the first card
        Console.WriteLine("Enter the first cell to reveal (e.g., A1): ");
        string move1 = Console.ReadLine();
        if (board.TryParseMove(move1, out row1, out col1) && board.IsCellHidden(row1, col1))
        {
            card1 = board.RevealCell(row1, col1);
            board.Print();
        }
        else
        {
            Console.WriteLine("Invalid move. Try again.");
            return false;
        }

        // Flip the second card
        Console.WriteLine("Enter the second cell to reveal (e.g., B2): ");
        string move2 = Console.ReadLine();
        if (board.TryParseMove(move2, out row2, out col2) && board.IsCellHidden(row2, col2) && (row1 != row2 || col1 != col2))
        {
            card2 = board.RevealCell(row2, col2);
        }
        else
        {
            Console.WriteLine("Invalid move. Try again.");
            return false;
        }

        // Check if the cards match
        if (card1 == card2)
        {
            Console.WriteLine("You found a match!");
            return true;
        }
        else
        {
            Console.WriteLine("No match. Better luck next time!");
            System.Threading.Thread.Sleep(2000);
            board.HideCell(row1, col1);
            return false;
        }
    }
}