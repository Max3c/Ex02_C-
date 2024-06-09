using System;

public static class GameUI
{
    public static void GetPlayerInfo(out string o_Player1Name, out bool o_IsAgainstComputer, out string o_Player2Name, out int o_BoardRows, out int o_BoardColumns)
    {
        Console.Write("Enter player 1 name: ");
        o_Player1Name = Console.ReadLine();
        o_Player1Name = ValidateUsername(o_Player1Name);

        Console.Write("Play against computer (y/n): ");
        char choice = Console.ReadKey().KeyChar;
        o_IsAgainstComputer = choice == 'y';
        Console.WriteLine();

        if (!o_IsAgainstComputer)
        {
            Console.Write("Enter player 2 name: ");
            o_Player2Name = Console.ReadLine();
            o_Player2Name = ValidateUsername(o_Player2Name);
        }
        else
        {
            o_Player2Name = "computer";
        }

        bool validInput = false;
        do
        {
            Console.Write("Enter board rows (4, 6): ");
            validInput = int.TryParse(Console.ReadLine(), out o_BoardRows) && (o_BoardRows == 4 || o_BoardRows == 6);
        } while (!validInput);

        validInput = false;
        do
        {
            Console.Write("Enter board columns (4, 6): ");
            validInput = int.TryParse(Console.ReadLine(), out o_BoardColumns) && (o_BoardColumns == 4 || o_BoardColumns == 6);
        } while (!validInput);
    }

    private static string ValidateUsername(string i_Name)
    {
        while (i_Name.Length >= 20 || i_Name.Contains(" "))
        {
            Console.WriteLine("Invalid name, please enter a name with less than 20 characters and no spaces");
            i_Name = Console.ReadLine();
        }
        return i_Name;
    }
}
