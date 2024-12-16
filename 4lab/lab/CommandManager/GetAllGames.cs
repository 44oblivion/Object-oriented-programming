class GetAllGames : ICommand
{
    public GameManager _gameManager;
    
    public GetAllGames(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.PrintGameResults();
    }

    public string GetDescription()
    {
        return "Get all Games";
    }
}