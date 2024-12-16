    public abstract class GameResult
    {
        public int GameIndex { get; set; }
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int RatingChange { get; set; }

        public string GameType { get; set; }
        private static int globalGameIndex = 1;

        public GameResult (string player, string opponent, string winner, string gameType)
        {
            GameIndex = globalGameIndex++;
            Player = player;
            Opponent = opponent;
            Winner = winner;
            GameType = gameType;
            RatingChange = RatingGenereting();
        }

        public abstract int RatingGenereting();
    }

    public class TrainingGame : GameResult {
        public TrainingGame(string player, string opponent, string winner,string gameType) : base( player, opponent, winner, gameType) {
            
        }

        public override int RatingGenereting() {
            return 0;
        }

    }

    public class StandartGame : GameResult {
        public StandartGame(string player, string opponent, string winner,string gameType) : base(player, opponent, winner, gameType) {
            
        }

        public override int RatingGenereting() {
            Random random = new Random();
            int rating = random.Next(1, 31);
            return rating;
        }

    }
