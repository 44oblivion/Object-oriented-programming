public interface iAccountService{
    void AddAccount(GameAccount account);
    void RemoveAccount(GameAccount account);
    void UpdateAccount(int id, string username, int rating, int gamesCount);
    GameAccount GetAccountByUserID(int id);
    List<GameAccount> GetAllAccounts();
}