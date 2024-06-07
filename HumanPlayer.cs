using System;
using Ex02.ConsoleUtils;
public static class HumanPlayer
{
    public static bool MakeMove(Board board)
    {
        int row1, col1, row2, col2;
        char card1, card2;


        // Flip the first card
        Console.WriteLine("Enter the first cell to reveal (e.g., A1): ");
        string move1 = Console.ReadLine();
        do {
            if(move1 == "Q" || move1=="q")
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Goodbye!");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            if (!board.TryParseMove(move1, out row1, out col1) || !board.IsCellHidden(row1, col1))
            {
                Console.WriteLine("Invalid move. Try again.");
                move1 = Console.ReadLine();
            }
        } while (!board.TryParseMove(move1, out row1, out col1) || !board.IsCellHidden(row1, col1));
        
        card1 = board.RevealCell(row1, col1);
        Ex02.ConsoleUtils.Screen.Clear();
        board.Print();
        // Flip the second card
        Console.WriteLine("Enter the second cell to reveal (e.g., B2): ");
        string move2 = Console.ReadLine();
        do{
            if(move2 == "Q" || move2=="q")
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Goodbye!");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            if (!board.TryParseMove(move2, out row2, out col2) || !board.IsCellHidden(row2, col2) || (row1 == row2 && col1 == col2))
            {
                Console.WriteLine("Invalid move. Try again.");
                move2 = Console.ReadLine();
            }
        } while (!board.TryParseMove(move2, out row2, out col2) || !board.IsCellHidden(row2, col2) || (row1 == row2 && col1 == col2));

        card2 = board.RevealCell(row2, col2);
        Ex02.ConsoleUtils.Screen.Clear();
        board.Print();
        
        // Check if the cards match
        if (card1 == card2)
        {   
            Console.WriteLine("\nYou found a match!");
            System.Threading.Thread.Sleep(5000); 
            Ex02.ConsoleUtils.Screen.Clear();
            return true;

        }
        else
        {
            Console.WriteLine("\nNo match. Better luck next time!");
            System.Threading.Thread.Sleep(5000);
            board.HideCell(row1, col1);
            board.HideCell(row2, col2);
            Ex02.ConsoleUtils.Screen.Clear();
            return false;
        }
    }
}