using System;

public class Board
{
    private char[,] m_Cells;
    private bool[,] m_Revealed;
    public int Rows { get; }
    public int Columns { get; }
    public Random m_Random = new Random();

    public Board(int rows, int columns)
    {
        if (rows < 4 || rows > 6 || rows % 2 != 0 || columns < 4 || columns > 6 || columns % 2 != 0)
        {
            throw new ArgumentException("Board dimensions must be even and between 4x4 and 6x6.");
        }

        Rows = rows;
        Columns = columns;
        m_Cells = new char[Rows,Columns];
        m_Revealed = new bool[Rows,Columns];
        initializeBoard();
    }

    private void initializeBoard()
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
            int j = m_Random.Next(i + 1);
            char temp = boardLetters[i];
            boardLetters[i] = boardLetters[j];
            boardLetters[j] = temp;
        }

        int k = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                m_Cells[i, j] = boardLetters[k++];
                m_Revealed[i, j] = false;
            }
        }
    }
    public void Print()
    {
        Console.Write("  ");
        for (int c = 0; c < Columns; c++)
        {
            Console.Write((char)('A' + c) + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < Rows; i++)
        {
            Console.Write($"{i + 1} ");
            for (int j = 0; j < Columns; j++)
            {
                if (m_Revealed[i, j])
                {
                    Console.Write($"{m_Cells[i, j]} ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }
    }

    public char HideCell(int row, int col)
    {
        m_Revealed[row, col] = false;
        return m_Cells[row, col];
    }
    public char RevealCell(int row, int col)
    {
        m_Revealed[row, col] = true;
        return m_Cells[row, col];
    }

    public bool IsCellHidden(int row, int col)
    {
        return !m_Revealed[row, col];
    }

    public bool TryParseMove(string move, out int row, out int col)
    {
        row = col = -1;
        if (move.Length != 2) return false;
        if (move[0] < 'A' || move[0] >= 'A' + Columns) return false;
        if (move[1] < '1' || move[1] >= '1' + Rows) return false;

        col = move[0] - 'A';
        row = move[1] - '1';
        return true;
    }

    public string GetCellName(int row, int col)
    {
        return $"{(char)('A' + col)}{(row + 1)}";
    }

    public bool IsFull()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (!m_Revealed[i, j]) return false;
            }
        }
        return true;
    }
}
