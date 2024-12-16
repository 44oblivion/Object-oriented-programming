using System;

public class GameAccount
{
    public string UserName { get; set; }
    private int rating = 1;

    public int CurrentRating
    {
        get { return rating; }
        set { if (value < 1) rating = 1; else rating = value; }
    }

    public int GamesCount { get; set; }
    private string gameHistory = "";
    private static Random random = new Random();
    public int PlayerId { get; set; }
    public static int PlayerIdCounter = 0;

    public GameAccount(string userName)
    {
        PlayerIdCounter++;
        UserName = userName;
        CurrentRating = 1;
        GamesCount = 0;
        PlayerId = PlayerIdCounter;
    }

    // Метод для перемоги
    public virtual void WinGame(GameResult game)
    {
            int rating = game.RatingGenereting();
            CurrentRating += rating;
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
            }
            GamesCount++;
        }
    
    
    // Метод для поразки
    public virtual void LoseGame(GameResult game)
    {
        
            int rating = game.RatingGenereting();
            CurrentRating -= rating;
            if (rating < 0)
            {
                throw new Exception("Рейтинг на який грають не може бути 0 або від'ємним.");
            }
            GamesCount++;
        }
        

    public virtual void AddGameHistory(string opponentName, bool isWin, int ratingChange)
    {
        string result = isWin ? "Перемога" : "Поразка";
        gameHistory += $"Гра проти {opponentName}: {result} на {ratingChange} рейтингу\n";
    }

    public virtual void GetStats()
    {
        Console.WriteLine($"Статистика гравця {UserName}:");
        Console.WriteLine($"Поточний рейтинг {UserName}: {CurrentRating}");
        Console.WriteLine();
    }
 

}

    class StandartAccount : GameAccount {
        public StandartAccount(string userName) : base(userName) {}
            public override void WinGame(GameResult game) {
                base.WinGame(game);
                }
            public override void LoseGame(GameResult game) {
                base.LoseGame(game);
                }
            }
         
    
    class WinStreakAccount : GameAccount {
        private int winCount = 0;
        public WinStreakAccount(string userName) : base(userName) {}
            public override void WinGame(GameResult game) {
                Random random = new Random();
                int rating = random.Next(1, 31);
                
                if (rating < 0)
                {
                    throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
                }
                CurrentRating += winCount + rating;
                GamesCount++;
                winCount++;
                }
            public override void LoseGame(GameResult game) {
                base.LoseGame(game);
                winCount = 0;
                }
            }

        class loseStreakAccount : GameAccount{
            private int loseCount = 0;
            public loseStreakAccount(string userName) : base(userName) {}
                public override void WinGame(GameResult game) {
                    base.WinGame(game);
                    loseCount = 0;
                    }
                public override void LoseGame(GameResult game) {
                    Random random = new Random();
                    int rating = random.Next(1, 31);
                    if (rating < 0)
                    {
                        throw new ArgumentException("Рейтинг на який грають не може бути 0 або від'ємним.");
                    }
                    CurrentRating -= loseCount + rating;
                    GamesCount++;
                    loseCount++;
                    }
                }
