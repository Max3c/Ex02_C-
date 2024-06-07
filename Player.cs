public class Player
{
    private string m_Name;
    private char m_Symbol;
    private bool m_IsHuman;

    public string Name => m_Name;
    public char Symbol => m_Symbol;
    public bool IsHuman => m_IsHuman;

    public Player(string name, char symbol, bool isHuman)
    {
        m_Name = name;
        m_Symbol = symbol;
        m_IsHuman = isHuman;
    }
}
