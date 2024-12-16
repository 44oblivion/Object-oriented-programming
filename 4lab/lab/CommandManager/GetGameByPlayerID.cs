class GetGameByPlayerID : ICommand
{
    public GameManager _gameManager;
    
    public GetGameByPlayerID(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Enter player ID:");
        int playerID = Convert.ToInt32(Console.ReadLine());
        _gameManager.FindGamesByUserId(playerID);
    }

    public string GetDescription()
    {
        return "Get game by player ID";
    }
}