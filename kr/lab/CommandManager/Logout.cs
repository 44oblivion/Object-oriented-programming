class Logout : ICommand
{
    static public GameManager _gameManager;

    public Logout(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        _gameManager.Logout();
    }

    public string GetDescription() => "Вийти з акаунту";
}