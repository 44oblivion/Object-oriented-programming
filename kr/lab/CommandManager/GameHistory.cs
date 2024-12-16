public class GameHistory : ICommand
{
    public GameManager _gameManager;
    
    public GameHistory(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.GetAccountGameHistory();
    }

    public string GetDescription()
    {
        return "Історія ігор";
    }
}