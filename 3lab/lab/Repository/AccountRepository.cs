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
    public void Update(int id, string UserName, int Rating, int GamesCount)
    {
        _accounts[id].UserName = UserName;
        _accounts[id].CurrentRating = Rating;
        _accounts[id].GamesCount = GamesCount;
    }
    
    public GameAccount GetByUserID(int id)
    {
        return _accounts.Find(x => x.PlayerId == id);
    }
    public List<GameAccount> GetAll()
    {
        return _accounts;
    }
}