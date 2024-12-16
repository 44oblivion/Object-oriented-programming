public class GameAccountRepository : IGameAccountRepository
{
    private List<GameAccount> _accounts = new List<GameAccount>();
    public GameAccountRepository(List<GameAccount> accounts)
    {
        _accounts = accounts;
    }

    public void Add(GameAccount account)
    {
        _accounts.Add(account);
    }
    public void Remove(GameAccount account)
    {
        _accounts.Remove(account);
    }
    public void Update(int id, string UserName)
    {
        _accounts.Find(x => x.PlayerId == id).UserName = UserName;
    }

    public GameAccount GetByUserName(string userName)
    {
        return _accounts.Find(x => x.UserName == userName);
    }
    public List<GameAccount> GetAll()
    {
        return _accounts;
    }
}