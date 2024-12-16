public interface IGameAccountRepository{
    void Add(GameAccount account);
    void Remove(GameAccount account);
    void Update(int id, string username, int rating, int gamesCount);
    GameAccount GetByUserID(int id);
    List<GameAccount> GetAll();
}