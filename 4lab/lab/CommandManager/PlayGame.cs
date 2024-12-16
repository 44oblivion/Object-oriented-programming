class PlayGame : ICommand
{
    public GameManager _gameManager;
    
    public PlayGame(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Input count of Games to play:");
        int count = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input First player ID:");
        int player1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input Second player ID:");
        int player2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input Game type:");
        string gameType = Console.ReadLine();
        _gameManager.SimulateGames(count, player1, player2, gameType);
    }

    public string GetDescription()
    {
        return "Play game";
    }
}