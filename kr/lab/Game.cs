    public abstract class GameResult
    {
        public int GameIndex { get; set; }
        public GameAccount Player { get; set; }
        public GameAccount Opponent { get; set; }
        public GameAccount Winner { get; set; }
        public int RatingChange { get; set; }
        public string GameType { get; set; }
        private static int globalGameIndex = 1;

        public GameResult (GameAccount player, GameAccount opponent, GameAccount winner, string gameType)
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
        public TrainingGame(GameAccount player, GameAccount opponent, GameAccount winner,string gameType) : base( player, opponent, winner, gameType) {
            
        }

        public override int RatingGenereting() {
            return 0;
        }

    }

    public class StandartGame : GameResult {
        public StandartGame(GameAccount player, GameAccount opponent, GameAccount winner,string gameType) : base(player, opponent, winner, gameType) {
            
        }

        public override int RatingGenereting() {
            return 20;
        }

    }
