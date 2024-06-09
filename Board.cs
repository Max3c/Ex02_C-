using System;

public class Board
{
    private char[,] m_cells;
    private bool[,] m_revealed;
    public int Rows { get; }
    public int Columns { get; }
    public Random m_random = new Random();

    public Board(int i_rows, int i_columns)
    {
        if (i_rows < 4 || i_rows > 6 || i_rows % 2 != 0 || i_columns < 4 || i_columns > 6 || i_columns % 2 != 0)
        {
            throw new ArgumentException("Board dimensions must be even and between 4x4 and 6x6.");
        }

        Rows = i_rows;
        Columns = i_columns;
        m_cells = new char[Rows, Columns];
        m_revealed = new bool[Rows, Columns];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        int pairs = (Rows * Columns) / 2;
        char[] boardLetters = new char[Rows * Columns];

        for (int i = 0; i < pairs; i++)
        {
            boardLetters[i * 2] = letters[i];
            boardLetters[i * 2 + 1] = letters[i];
        }

        for (int i = boardLetters.Length - 1; i > 0; i--)
        {
            int j = m_random.Next(i + 1);
            char temp = boardLetters[i];
            boardLetters[i] = boardLetters[j];
            boardLetters[j] = temp;
        }

        int k = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                m_cells[i, j] = boardLetters[k++];
                m_revealed[i, j] = false;
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("");
        Console.Write(" ");
        for (int c = 0; c < Columns; c++)
        {
            Console.Write("   " + (char)('A' + c));
        }
        Console.WriteLine();
        Console.WriteLine("  " + new string('=', Columns * 4));
        for (int i = 0; i < Rows; i++)
        {
            Console.Write($"{i + 1} |");
            for (int j = 0; j < Columns; j++)
            {
                if (m_revealed[i, j])
                {
                    Console.Write($" {m_cells[i, j]} |");
                }
                else
                {
                    Console.Write("   |");
                }
            }
            Console.WriteLine();
            Console.WriteLine("  " + new string('=', Columns * 4));
        }
    }

    public char HideCell(int i_row, int i_col)
    {
        m_revealed[i_row, i_col] = false;
        
        return m_cells[i_row, i_col];
    }

    public char RevealCell(int i_row, int i_col)
    {
        m_revealed[i_row, i_col] = true;

        return m_cells[i_row, i_col];
    }

    public bool IsCellHidden(int i_row, int i_col)
    {
        return !m_revealed[i_row, i_col];
    }

    public bool TryParseMove(string i_move, out int o_row, out int o_col)
    {
        o_row = o_col = -1;
        if (i_move.Length != 2) return false;
        if (i_move[0] < 'A' || i_move[0] >= 'A' + Columns) return false;
        if (i_move[1] < '1' || i_move[1] >= '1' + Rows) return false;

        o_col = i_move[0] - 'A';
        o_row = i_move[1] - '1';

        return true;
    }

    public string GetCellName(int i_row, int i_col)
    {
        return $"{(char)('A' + i_col)}{(i_row + 1)}";
    }

    public bool IsFull()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (!m_revealed[i, j]) return false;
            }
        }

        return true;
    }
}
