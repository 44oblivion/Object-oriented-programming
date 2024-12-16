class GetPlayerStats : ICommand
{
    public GameManager _gameManager;
    
    public GetPlayerStats(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.PrintAccountStats();
    }

    public string GetDescription()
    {
        return "Мій профіль";
    }
}