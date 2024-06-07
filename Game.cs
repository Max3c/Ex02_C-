using System;
using Ex02.ConsoleUtils;

public class Game
{
    private Player m_Player1;
    private Player m_Player2;
    private Board m_Board;
    private bool m_IsPlayer1Turn;

    public Game()
    {
        m_IsPlayer1Turn = true;
        Ex02.ConsoleUtils.Screen.Clear();
        InitializeGame();

    }

    public bool Start()
    {
        m_Board.Print();
        while (!IsGameOver())
        {
            TakeTurn();
            m_Board.Print();
        }
        AnnounceWinner();
        Console.WriteLine("Would you like to play again(Y/N)?");
        string playAgain;
        playAgain = Console.ReadLine();
        if(playAgain == "Y" || playAgain == "y")
        {
            Ex02.ConsoleUtils.Screen.Clear();
            return true;
        }
        else
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Goodbye!");
            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            return false;
        }
    }

    private void InitializeGame()
    {
        GameUI.GetPlayerInfo(out string player1Name, out bool isAgainstComputer, out string player2Name, out int rows, out int columns);
        m_Player1 = new Player(player1Name, 0, true);
        if(isAgainstComputer)
        {
            m_Player2 = new Player(player2Name, 0, false);
        }
        else
        {
            m_Player2 = new Player(player2Name, 0, true);
        }
        m_Board = new Board(rows, columns);
        Ex02.ConsoleUtils.Screen.Clear();
    }

    private void TakeTurn()
    {
        Player currentPlayer = m_IsPlayer1Turn ? m_Player1 : m_Player2; 
        Console.WriteLine($"\n{(currentPlayer.Name)}'s turn");

        bool correctGuess = currentPlayer.MakeMove(m_Board);
        
        
        if(correctGuess){
            int currScore = currentPlayer.Score;
           currentPlayer.increaseScore();
        }
        else{
            m_IsPlayer1Turn = !m_IsPlayer1Turn;
        }
    }

    private bool IsGameOver()
    {
        return m_Board.IsFull();
    }

    private void AnnounceWinner()
    {
        if(m_Player1.Score > m_Player2.Score)
        {
            Console.WriteLine($"\n{m_Player1.Name} wins! with {m_Player1.Score} points!");
            Console.WriteLine($"\n{m_Player2.Name} had {m_Player2.Score} points.");
        }
        else if(m_Player1.Score < m_Player2.Score)
        {
            Console.WriteLine($"{m_Player2.Name} wins! with {m_Player2.Score} points!");
            Console.WriteLine($"\n{m_Player1.Name} had {m_Player1.Score} points.");
        }
        else
        {
            Console.WriteLine($"\nIt's a tie! With a tied score of {m_Player1.Score} points!");

        }
    }
}

