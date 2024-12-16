class UpdatePlayer : ICommand
{
    private GameManager _gameManager;

    public UpdatePlayer(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Execute()
    {
        Console.WriteLine("Виберіть новий нікнейм:");
        string username = Console.ReadLine();
        _gameManager.UpdatePlayer(username);
    }
        public string GetDescription()
    {
        return "Оновити акаунт";
    }
}