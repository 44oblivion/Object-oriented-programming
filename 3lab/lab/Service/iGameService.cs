public interface IGameService{
    void AddGame(GameResult game);
    void RemoveGame(GameResult game);
    void UpdateGame(int id, GameAccount player1, GameAccount player2,GameAccount winner);
    List<GameResult> GetGamesByUserID(int id);
    GameResult GetGamesByID(int id);
    List<GameResult> GetAllGames();
}