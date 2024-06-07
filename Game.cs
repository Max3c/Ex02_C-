using System;

public class Game
{
    private Player m_Player1;
    private Player m_Player2;
    private Board m_Board;
    private bool m_IsPlayer1Turn;

    public Game()
    {
        m_IsPlayer1Turn = true;
        InitializeGame();
    }

    public void Start()
    {
        m_Board.Print();
        while (!IsGameOver())
        {
            TakeTurn();
            m_Board.Print();
        }
        AnnounceWinner();
    }

    private void InitializeGame()
    {
        GameUI.GetPlayerInfo(out string player1Name, out bool isAgainstComputer, out string player2Name, out int rows, out int columns);
        m_Board = new Board(rows, columns);
    }

    private void TakeTurn()
    {
        console.WriteLine("started takeTurn");
        Console.WriteLine($"{(m_IsPlayer1Turn ? m_Player1.Name : m_Player2.Name)}'s turn.");
        console.WriteLine("plrinter out plater names");

        Player currentPlayer = m_IsPlayer1Turn ? m_Player1 : m_Player2;
        currentPlayer.MakeMove(m_Board);

        m_IsPlayer1Turn = !m_IsPlayer1Turn;
    }

    private bool IsGameOver()
    {
        return m_Board.CheckWinner('X') || m_Board.CheckWinner('O') || m_Board.IsFull();
    }

    private void AnnounceWinner()
    {
        if (m_Board.CheckWinner('X'))
        {
            Console.WriteLine($"{m_Player1.Name} wins!");
        }
        else if (m_Board.CheckWinner('O'))
        {
            Console.WriteLine($"{m_Player2.Name} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }
}

