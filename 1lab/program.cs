using System;

class Program
{
    static void Main(string[] args)
    {
        GameAccount player1 = new GameAccount("Yehor");
        GameAccount player2 = new GameAccount("Alice");
        GameAccount player3 = new GameAccount("Bob");
        GameAccount[] players = { player1, player2, player3 };
        
        GameManager gameManager = new GameManager(players);
        gameManager.SimulateGames(10);
        gameManager.PrintGameResults();

        player1.GetStats();
        player2.GetStats();
        player3.GetStats();
    }
}
