public interface IGameService{
    
    void AddGame(GameResult game);
    List<GameResult> GetGamesByPlayer(GameAccount player);
    List<GameResult> GetAllGames();
}