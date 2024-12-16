using System;

class Program
{
    static void Main(string[] args)
    {


        GameManager gameManager = new GameManager();
        
        gameManager.CreateAccout("Vasya", "standart");
        gameManager.CreateAccout("Petya", "standart");
        gameManager.CreateAccout("Старий Бох", "winstreak");
        gameManager.CreateAccout("zxcursed", "standart");

        gameManager.SimulateGames(10, 1, 2, "standart");
        gameManager.SimulateGames(10, 2, 3, "training");

        gameManager.UpdateGame(12, "standart", 2, 1, 2);
        gameManager.DeleteGame(15);

        gameManager.UpdatePlayer(3, "asdasd",10000, 20);
        gameManager.DeleteAccount(1);



        gameManager.PrintAccountStats();
        gameManager.PrintGameResults();
        
        gameManager.FindGamesByUserId(2);


    }
}
