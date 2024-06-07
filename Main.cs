using System;
public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
		bool restart = game.Start();
		while(restart){
			game = new Game();
			restart = game.Start();
		}
    }
}
