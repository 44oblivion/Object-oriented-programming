public class GameResult
{
    public int GameIndex { get; }
    public string Player { get; }
    public string Opponent { get; }
    public string Winner { get; }
    public int RatingChange { get; }

    private static int globalGameIndex = 1;

    public GameResult(string player, string opponent, string winner, int ratingChange)
    {
        GameIndex = globalGameIndex++;
        Player = player;
        Opponent = opponent;
        Winner = winner;
        RatingChange = ratingChange;
    }
}
