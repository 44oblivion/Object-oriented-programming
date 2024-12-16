class CreatePlayer : ICommand
{
    public GameManager _gameManager;
    
    public CreatePlayer(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Enter player name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter player type:");
        string type = Console.ReadLine();
        _gameManager.CreateAccout(name, type);

    }

    public string GetDescription()
    {
        return "Create player";
    }
}