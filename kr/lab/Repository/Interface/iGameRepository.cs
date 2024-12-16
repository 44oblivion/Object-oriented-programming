public interface IGameRepository{
    void Add(GameResult game);
    List<GameResult> GetGamesByPlayer(GameAccount player);
    List<GameResult> GetAll(); 
}