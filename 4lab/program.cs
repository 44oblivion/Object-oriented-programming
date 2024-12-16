using System;

class Program
{
    static void Main(string[] args)
    {


        GameManager gameManager = new GameManager();

        CommandManager commandManager = new CommandManager();

        commandManager.RegisterCommand("1", new CreatePlayer(gameManager));
        commandManager.RegisterCommand("2", new GetAllPlayers(gameManager));
        commandManager.RegisterCommand("3", new GetGameByPlayerID(gameManager));
        commandManager.RegisterCommand("4", new GetAllGames(gameManager));
        commandManager.RegisterCommand("5", new PlayGame(gameManager));

        commandManager.RegisterCommand("0", new ExitProgram());

        while (true)
        {
            Console.WriteLine("Enter command:");
            commandManager.ShowCommands();
            string command = Console.ReadLine();
            commandManager.ExecuteCommand(command);
        }

        
        
        // gameManager.CreateAccout("Vasya", "standart");
        // gameManager.CreateAccout("Petya", "standart");
        // gameManager.CreateAccout("Старий Бох", "winstreak");
        // gameManager.CreateAccout("zxcursed", "standart");

        // gameManager.SimulateGames(10, 1, 2, "standart");
        // gameManager.SimulateGames(10, 2, 3, "training");

        // gameManager.UpdateGame(12, "standart", 1, 0, 1);
        // gameManager.DeleteGame(15);

        // gameManager.UpdatePlayer(3, "asdasd",10000, 20);
        // gameManager.DeleteAccount(0);



        // gameManager.PrintAccountStats();
        // gameManager.PrintGameResults();
        
        // gameManager.FindGamesByUserId(2);


    }
}
