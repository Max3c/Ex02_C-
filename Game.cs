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

    public void Start()
    {
        m_Board.Print();
        while (!IsGameOver())
        {
            TakeTurn();
            //m_Board.Print();
        }
        AnnounceWinner();
        Console.WriteLine("Would you like to play again(Y/N)?");
        string playAgain;
        playAgain = Console.ReadLine();
        if(playAgain == "Y" || playAgain == "y")
        {
            Start();
        }
        else
        {
            Console.WriteLine("Goodbye!");
            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
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
        Console.WriteLine($"{(currentPlayer.Name)}'s turn. Score: {currentPlayer.Score}");
        

        bool correctGuess = currentPlayer.MakeMove(m_Board);
        
        if(correctGuess){
           m_IsPlayer1Turn = !m_IsPlayer1Turn;
           currentPlayer.increaseScore();
        }
        m_IsPlayer1Turn = !m_IsPlayer1Turn;
    }

    private bool IsGameOver()
    {
        return m_Board.IsFull();
    }

    private void AnnounceWinner()
    {
        if(m_Player1.Score > m_Player2.Score)
        {
            Console.WriteLine($"{m_Player1.Name} wins!");
        }
        else if(m_Player1.Score < m_Player2.Score)
        {
            Console.WriteLine($"{m_Player2.Name} wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

