public class DeletePlayer : ICommand
{
    public GameManager _gameManager;
    
    public DeletePlayer(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.DeleteAccount();
        Console.WriteLine("Акаунт видалено\n");
        UserSession.currentUser = null;
    }

    public string GetDescription()
    {
        return "Видалити акаунт";
    }
}