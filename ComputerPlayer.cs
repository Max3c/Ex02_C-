using System;

public static class ComputerPlayer
{
    private static Random s_Random = new Random();

    public static void MakeMove(Board board)
    {
        int row, col;
        do
        {
            row = s_Random.Next(board.Rows);
            col = s_Random.Next(board.Columns);
        } while (!board.IsCellHidden(row, col));

        board.RevealCell(row, col);
        Console.WriteLine($"Computer chose {board.GetCellName(row, col)}");
    }
}
