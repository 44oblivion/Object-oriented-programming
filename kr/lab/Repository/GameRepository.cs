public class GameRepository : IGameRepository
{
    public List<GameResult> _games = new List<GameResult>();
    public GameRepository(List<GameResult> games)
    {
        _games = games;
    }
    public void Add(GameResult game)
    {
        _games.Add(game);
    }


    public List<GameResult> GetGamesByPlayer(GameAccount player)
    {
        return _games.FindAll(x => x.Player == player);
    }

    public List<GameResult> GetAll()
    {
        return _games;
    }
}