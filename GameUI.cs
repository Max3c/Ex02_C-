using System;
public static class GameUI
{
    public static void GetPlayerInfo(out string player1Name, out bool isAgainstComputer, out string player2Name, out int boardRows, out int boardColumns)
    {
        Console.Write("Enter player 1 name: ");
        player1Name = Console.ReadLine();
        player1Name = validateUsername(player1Name);

    

        Console.Write("Play against computer (y/n): ");
        char choice = Console.ReadKey().KeyChar;
        isAgainstComputer = choice == 'y';
        Console.WriteLine();

        if (!isAgainstComputer)
        {
            Console.Write("Enter player 2 name: ");
            player2Name = Console.ReadLine();
            

        }
        else
        {
            player2Name = "computer";
        }

        bool validInput = false;
        do
        {
            Console.Write("Enter board rows (4, 6): ");
            validInput = int.TryParse(Console.ReadLine(), out boardRows) && (boardRows == 4 || boardRows == 6);
        } while (!validInput);

        validInput = false;
        do
        {
            Console.Write("Enter board columns (4, 6): ");
            validInput = int.TryParse(Console.ReadLine(), out boardColumns) && (boardColumns == 4 || boardColumns == 6);
        } while (!validInput);
    }

    private static string validateUsername(string name){
        while(name.Length >= 20 || name.Contains(" ")){
            Console.WriteLine("Invalid name, please enter a name with less than 20 characters and no spaces");
            name = Console.ReadLine();
        }
        return name;
    }
}
