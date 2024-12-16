using System;

public class GameAccount
{
    public string Password { get; set; }
    public string UserName { get; set; }
    private int rating = 1;

    public int CurrentRating
    {
        get { return rating; }
        set { if (value < 1) rating = 1; else rating = value; }
    }

    public int GamesCount { get; set; }
    public string gameHistory = "";
    private static Random random = new Random();
    public int PlayerId { get; set; }
    public static int PlayerIdCounter = 1;

    public GameAccount(string userName, string password)
    {
        UserName = userName;
        Password = password;
        CurrentRating = 1;
        GamesCount = 0;
        PlayerId = PlayerIdCounter;
        PlayerIdCounter++;
    }

    public virtual void WinGame(GameResult game)
    {
            int rating = game.RatingChange;
            CurrentRating += rating;
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
            }
            GamesCount++;
        }
    
    
    public virtual void LoseGame(GameResult game)
    {
        
            int rating = game.RatingChange;
            CurrentRating -= rating;
            if (rating < 0)
            {
                throw new Exception("Рейтинг на який грають не може бути 0 або від'ємним.");
            }
            GamesCount++;
        }
    public virtual void DrawGame(GameResult game)
    {
        int rating = 0;
        if (rating < 0)
        {
            throw new Exception("Рейтинг на який грають не може бути 0 або від'ємним.");
        }
        GamesCount++;
    }
 

}

    class StandartAccount : GameAccount {
        public StandartAccount(string userName, string password) : base(userName, password) {}
            public override void WinGame(GameResult game) {
                base.WinGame(game);
                }
            public override void LoseGame(GameResult game) {
                base.LoseGame(game);
                }
            }
         
    
    class WinStreakAccount : GameAccount {
        private int winCount = 0;
        public WinStreakAccount(string userName, string password) : base(userName, password) {}
            public override void WinGame(GameResult game) {
            int rating = game.RatingChange;
            CurrentRating = CurrentRating + rating + winCount;
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
            }
            GamesCount++;
            winCount++;
                }
            public override void LoseGame(GameResult game) {
                base.LoseGame(game);
                winCount = 0;
                }
            }

        class LoseStreakAccount : GameAccount{
            private int loseCount = 0;
            public LoseStreakAccount(string userName, string password) : base(userName, password) {}
                public override void WinGame(GameResult game) {
                    base.WinGame(game);
                    loseCount = 0;
                    }
                public override void LoseGame(GameResult game) {
                    int rating = game.RatingChange;
                    CurrentRating = CurrentRating - rating - loseCount;
                    if (rating < 0)
                    {
                        throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
                    }
                    
                    GamesCount++;
                    loseCount++;
                    }
                }
    class Bot : GameAccount{
        public Bot(string userName, string password) : base(userName, password) {}
            public override void WinGame(GameResult game) {
                CurrentRating = 0;
                GamesCount++;
                }
            public override void LoseGame(GameResult game) {
                CurrentRating = 0;
                GamesCount++;
                }
    }
