using System;

public class GameAccount
{
    public string UserName { get; }
    private int rating = 1;
    public int CurrentRating
    {
        get { return rating; }
        private set { rating = value < 1 ? 1 : value; }
    }

    public int GamesCount { get; private set; }
    private string gameHistory = "";
    private static Random random = new Random();

    public GameAccount(string userName)
    {
        UserName = userName;
        CurrentRating = 1;
        GamesCount = 0;
    }

    // Method for winning a game
    public void WinGame(string opponentName)
    {
        int ratingChange = random.Next(1, 31);
        CurrentRating += ratingChange;
        GamesCount++;
        AddGameHistory(opponentName, true, ratingChange);
    }

    // Method for losing a game
    public void LoseGame(string opponentName)
    {
        int ratingChange = random.Next(1, 31);
        CurrentRating -= ratingChange;
        GamesCount++;
        AddGameHistory(opponentName, false, ratingChange);
    }

    // Add the result of a game to history
    private void AddGameHistory(string opponentName, bool isWin, int ratingChange)
    {
        string result = isWin ? "Win" : "Loss";
        gameHistory += $"Game against {opponentName}: {result}, Rating change: {ratingChange}\n";
    }

    // Print player's stats
    public void GetStats()
    {
        Console.WriteLine($"Player {UserName} Stats:");
        Console.WriteLine("Game History:");
        Console.WriteLine(string.IsNullOrEmpty(gameHistory) ? "No games played" : gameHistory);
        Console.WriteLine($"Current Rating: {CurrentRating}\n");
    }
}
