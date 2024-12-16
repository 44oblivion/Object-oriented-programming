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
    public void Remove(GameResult game)
    {
        _games.Remove(game);
    }
    public void Update(int id, GameAccount player1, GameAccount player2,GameAccount winner)
    {
        var gameToUpdate = _games.FirstOrDefault(x => x.GameIndex == id);
        gameToUpdate.Player = player1;
        gameToUpdate.Opponent = player2;
        gameToUpdate.Winner = winner;
    }
    public GameResult GetByGameID(int id)
    {
        return _games[id];
    }
    public List<GameResult> GetAll()
    {
        return _games;
    }
}