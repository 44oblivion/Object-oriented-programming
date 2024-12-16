public interface IGameRepository{
    void Add(GameResult game);
    void Remove(GameResult game);
    void Update(int id, GameAccount player1, GameAccount player2, GameAccount winner);
    GameResult GetByGameID(int id);/* шукає ігру за айдішкою */
    List<GameResult> GetAll(); /* повертає список ігор */
}