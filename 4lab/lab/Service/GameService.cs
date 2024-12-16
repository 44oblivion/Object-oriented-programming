public class GameService : IGameService{
    private GameRepository _gameRepository;

    public GameService(GameRepository gameRepository){
        _gameRepository = gameRepository;
    }
    public void AddGame(GameResult game){
        _gameRepository.Add(game);
    }
    public void RemoveGame(GameResult game){
        _gameRepository.Remove(game);
    }
    public void UpdateGame(int id, GameAccount player1, GameAccount player2,GameAccount winner){
        _gameRepository.Update(id, player1, player2, winner);
    }
    public List<GameResult> GetGamesByUserID(int id){
        List<GameResult> games = _gameRepository._games.Where(x => x.Player.PlayerId == id || x.Opponent.PlayerId == id).ToList();
        return games;
    }

    public GameResult GetGamesByID(int id){
        return _gameRepository.GetByGameID(id);
    }
    public List<GameResult> GetAllGames(){
        return _gameRepository.GetAll();
    }

}