public class AccountService : iAccountService{
    private IGameAccountRepository _accountRepository;
    public AccountService(IGameAccountRepository accountRepository){
        _accountRepository = accountRepository;
    }
    public void AddAccount(GameAccount account){
        _accountRepository.Add(account);
    }

    public bool Login(string username, string password)
    {
        GameAccount user = _accountRepository.GetByUserName(username);
        if (user == null || user.Password != password)
        {
          return false;
        }

        UserSession.currentUser = user;
        return true;
    }

    public void Logout()
    {
        UserSession.currentUser = null;
    }

    public void RemoveAccount(GameAccount account){
        _accountRepository.Remove(account);
    }
    public void UpdateAccount(int id, string username){
        _accountRepository.Update(id, username);    
    }
    public GameAccount CurrentUserProfile(){
        return UserSession.currentUser;
    }
    public GameAccount GetByUserName(string userName){
        return _accountRepository.GetByUserName(userName);
    }
    public List<GameAccount> GetAllAccounts(){
        return _accountRepository.GetAll();
    }
}