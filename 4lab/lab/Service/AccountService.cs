public class AccountService : iAccountService{
    private IGameAccountRepository _accountRepository;
    public AccountService(IGameAccountRepository accountRepository){
        _accountRepository = accountRepository;
    }
    public void AddAccount(GameAccount account){
        _accountRepository.Add(account);
    }
    public void RemoveAccount(GameAccount account){
        _accountRepository.Remove(account);
    }
    public void UpdateAccount(int id, string username, int rating, int gamesCount){
        _accountRepository.Update(id, username, rating, gamesCount);    
    }
    public GameAccount GetAccountByUserID(int id){
        return _accountRepository.GetByUserID(id);
    }
    public List<GameAccount> GetAllAccounts(){
        return _accountRepository.GetAll();
    }
}