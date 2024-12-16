public class GameService : IGameService{
    private GameRepository _gameRepository;

    public GameService(GameRepository gameRepository){
        _gameRepository = gameRepository;
    }
    public void AddGame(GameResult game){
        _gameRepository.Add(game);
    }
    
    
    public List<GameResult> GetGamesByPlayer(GameAccount player){
        List<GameResult> games = _gameRepository._games.Where(x => x.Player == player || x.Opponent == player).ToList();
        return games;
    }

    
    public List<GameResult> GetAllGames(){
        return _gameRepository.GetAll();
    }

}