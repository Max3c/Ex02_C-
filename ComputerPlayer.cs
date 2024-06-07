using System;
using "Ex02.ConsoleUtils";
public static class ComputerPlayer
{
    private static Random s_Random = new Random();

    public static bool MakeMove(Board board)
    {
        int row1, col1, row2, col2;
        char card1, card2;

        // Flip the first card
        do
        {
            row1 = s_Random.Next(board.Rows);
            col1 = s_Random.Next(board.Columns);
        } while (!board.IsCellHidden(row1, col1));
        card1 = board.RevealCell(row1, col1);
        Console.WriteLine($"Computer chose {board.GetCellName(row1, col1)}");

        // Flip the second card
        do
        {
            row2 = s_Random.Next(board.Rows);
            col2 = s_Random.Next(board.Columns);
        } while (!board.IsCellHidden(row2, col2) || (row1 == row2 && col1 == col2));
        card2 = board.RevealCell(row2, col2);
        Console.WriteLine($"Computer chose {board.GetCellName(row2, col2)}");

        // Check if the cards match
        if (card1 == card2)
        {
            Console.WriteLine("Computer found a match!");
            return true;
        }
        else
        {
            Console.WriteLine("No match. Better luck next time, computer!");
            System.Threading.Thread.Sleep(2000);
            board.HideCell(row1, col1);
            Ex02.ConsoleUtilts.Screen.Clear();
            return false;
        }
    }
}