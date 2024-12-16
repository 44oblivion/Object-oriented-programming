public interface iAccountService{
    bool Login(string username, string password);
    void Logout();
    void AddAccount(GameAccount account);
    void RemoveAccount(GameAccount account);
    void UpdateAccount(int id, string username);
    GameAccount GetByUserName(string userName);
    GameAccount CurrentUserProfile();   
    List<GameAccount> GetAllAccounts();
}