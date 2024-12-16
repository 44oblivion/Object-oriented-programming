class PlayGame : ICommand
{
    public GameManager _gameManager;
    
    public PlayGame(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Input Game type:");
        string gameType;
        while (true)
        {
            gameType = Console.ReadLine();
            if (gameType == "standart" || gameType == "training")
            {
                _gameManager.SimulateGames(gameType);
                break;
            }
            else
            {
                Console.WriteLine("Неправильний тип. Будь ласка, введіть правильний тип гри (standart, training):");
            }
        }
    }

    public string GetDescription()
    {
        return "Грати в гру";
    }
}