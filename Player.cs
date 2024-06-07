public class Player
{
    private string m_Name;
    private int m_Score;
    private bool m_IsHuman;
    public string Name { get { return m_Name; } }
    public int Score { get { return m_Score; } }
    public bool IsHuman { get { return m_IsHuman; } }

    public Player(string name, int score, bool isHuman)
    {
        m_Name = name;
        m_Score = score;
        m_IsHuman = isHuman;
    }
    public void MakeMove(Board board)
    {
        if (IsHuman)
        {
            HumanPlayer.MakeMove(board);
        }
        else
        {
            ComputerPlayer.MakeMove(board);
        }
    }
}
