using System;
using Ex02.ConsoleUtils;

public static class HumanPlayer
{
    public static bool MakeMove(Board io_Board)
    {
        int row1, col1, row2, col2;
        char card1, card2;

        // Flip the first card
        Console.WriteLine("Enter the first cell to reveal (e.g., A1): ");
        string move1 = Console.ReadLine();
        while (!isValidMove(io_Board, move1, out row1, out col1))
        {
            if (isQuitCommand(move1))
            {
                handleQuit();
            }
            Console.WriteLine("Invalid move. Try again.");
            move1 = Console.ReadLine();
        }
        
        card1 = io_Board.RevealCell(row1, col1);
        Screen.Clear();
        io_Board.Print();

        // Flip the second card
        Console.WriteLine("Enter the second cell to reveal (e.g., B2): ");
        string move2 = Console.ReadLine();
        while (!isValidMove(io_Board, move2, out row2, out col2) || (row1 == row2 && col1 == col2))
        {
            if (isQuitCommand(move2))
            {
                handleQuit();
            }
            Console.WriteLine("Invalid move. Try again.");
            move2 = Console.ReadLine();
        }

        card2 = io_Board.RevealCell(row2, col2);
        Screen.Clear();
        io_Board.Print();
        bool isMatch = card1 == card2;

        // Check if the cards match
        if (card1 == card2)
        {   
            Console.WriteLine("\nYou found a match!");
            System.Threading.Thread.Sleep(2000); 
            Screen.Clear();
            return isMatch;
        }
        else
        {
            Console.WriteLine("\nNo match. Better luck next time!");
            System.Threading.Thread.Sleep(2000);
            io_Board.HideCell(row1, col1);
            io_Board.HideCell(row2, col2);
            Screen.Clear();

            return isMatch;
        }
    }

    private static bool isValidMove(Board i_Board, string i_Move, out int o_Row, out int o_Col)
    {
        return i_Board.TryParseMove(i_Move, out o_Row, out o_Col) && i_Board.IsCellHidden(o_Row, o_Col);
    }

    private static bool isQuitCommand(string i_Command)
    {
        return i_Command.Equals("Q", StringComparison.OrdinalIgnoreCase);
    }

    private static void handleQuit()
    {
        Screen.Clear();
        Console.WriteLine("Goodbye!");
        System.Threading.Thread.Sleep(2000);
        Environment.Exit(0);
    }
}
