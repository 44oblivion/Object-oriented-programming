using System;

class Program
{
    static void Main(string[] args)
    {


        GameManager gameManager = new GameManager();

        CommandManager commandManager = new CommandManager();


        commandManager.RegisterCommand("login", new Login(gameManager));
        commandManager.RegisterCommand("create", new CreatePlayer(gameManager));
        commandManager.RegisterCommand("1", new PlayGame(gameManager));
        commandManager.RegisterCommand("2", new UpdatePlayer(gameManager));
        commandManager.RegisterCommand("3", new GetPlayerByUserName(gameManager)); 
        commandManager.RegisterCommand("4", new GetPlayerStats(gameManager));
        commandManager.RegisterCommand("5", new GameHistory(gameManager));

        commandManager.RegisterCommand("8", new DeletePlayer(gameManager));
        commandManager.RegisterCommand("9", new Logout(gameManager));
        commandManager.RegisterCommand("exit", new ExitProgram());

        while (true)
        {
            commandManager.ShowCommands();
            string command = Console.ReadLine();
            commandManager.ExecuteCommand(command);
        }

    }
}
