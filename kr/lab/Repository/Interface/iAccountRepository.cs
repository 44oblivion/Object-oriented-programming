public interface IGameAccountRepository{
    void Add(GameAccount account);
    void Remove(GameAccount account);
    void Update(int id, string username);
    GameAccount GetByUserName(string userName); 
    List<GameAccount> GetAll();
}