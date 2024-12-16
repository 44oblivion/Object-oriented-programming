using System;

class Program
{
    static void Main(string[] args)
    {
        GameAccount player1 = new GameAccount("Yehor");
        GameAccount player2 = new GameAccount("Alice");
        GameAccount player3 = new GameAccount("Bob");

        GameManager gameManager = new GameManager();

        gameManager.SimulateGames(10, player1, player2, "standart");
        gameManager.SimulateGames(10, player1, player3, "training");
        gameManager.SimulateGames(10, player2, player3, "standart");
        

        gameManager.PrintGameResults();

        player1.GetStats();
        player2.GetStats();
        player3.GetStats();
    }
}
