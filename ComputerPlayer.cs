using System;
using Ex02.ConsoleUtils;

public static class ComputerPlayer
{
    private static Random m_Random = new Random();


    public static bool MakeMove(Board board)
    {
        
        int row1, col1, row2, col2;
        char card1, card2;

        // Flip the first card
        do
        {
            row1 = m_Random.Next(board.Rows);
            col1 = m_Random.Next(board.Columns);
        } while (!board.IsCellHidden(row1, col1));
        card1 = board.RevealCell(row1, col1);
        

        // Flip the second card
        do
        {
            row2 = m_Random.Next(board.Rows);
            col2 = m_Random.Next(board.Columns);
        } while (!board.IsCellHidden(row2, col2) || (row1 == row2 && col1 == col2));
        card2 = board.RevealCell(row2, col2);
        
        Ex02.ConsoleUtils.Screen.Clear();

        board.Print();
        Console.WriteLine($"\nComputer chose {board.GetCellName(row1, col1)}");
        Console.WriteLine($"Computer chose {board.GetCellName(row2, col2)}");

        
        if (card1 == card2)
        {
            Console.WriteLine("Computer found a match!");
            
            System.Threading.Thread.Sleep(5000);
            Ex02.ConsoleUtils.Screen.Clear();

            return true;
        }
        else
        {
            Console.WriteLine("No match. Better luck next time, computer!");
            System.Threading.Thread.Sleep(5000);
            board.HideCell(row1, col1);
            board.HideCell(row2, col2);
            Ex02.ConsoleUtils.Screen.Clear();
            return false;
        }
    }
}