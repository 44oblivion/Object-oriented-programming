public class DBcontext{
    public List<GameResult> Games {get; set;}
    public List<GameAccount> Accounts {get; set;}

    public DBcontext(List<GameResult> games, List<GameAccount> accounts){   
        Games = games;
        Accounts = accounts;
    }
}