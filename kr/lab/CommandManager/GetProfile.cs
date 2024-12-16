class CurrentUserProfile : ICommand
{
    public GameManager _gameManager;
    
    public CurrentUserProfile(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        _gameManager.PrintCurrentUserProfile();
    }

    public string GetDescription()
    {
        return "Мій профіль";
    }
}