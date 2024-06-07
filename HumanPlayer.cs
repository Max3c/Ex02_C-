using System;
public static class HumanPlayer
{
    public static void MakeMove(Board board)
    {
        bool validMove = false;
        while (!validMove)
        {
            Console.WriteLine("Enter the cell to reveal (e.g., A1): ");
            string move = Console.ReadLine();
            if (board.TryParseMove(move, out int row, out int col) && board.IsCellHidden(row, col))
            {
                board.RevealCell(row, col);
                validMove = true;
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }
}

