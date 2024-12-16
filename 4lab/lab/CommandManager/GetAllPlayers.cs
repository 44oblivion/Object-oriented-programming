class GetAllPlayers : ICommand
{
    public GameManager _gameManager;
    
    public GetAllPlayers(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.PrintAccountStats();
    }

    public string GetDescription()
    {
        return "Get all players";
    }
}