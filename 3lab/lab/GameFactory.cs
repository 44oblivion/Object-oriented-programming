
public static class GameFactory
    {
        public static GameResult CreateGame(string gameType, GameAccount player1, GameAccount player2, GameAccount winner)
        {
            switch (gameType.ToLower())
            {
                case "standart":
                    return new StandartGame(player1, player2, winner, gameType);
                case "training":
                    return new TrainingGame(player1, player2, winner, gameType);
                default:
                    throw new ArgumentException("Invalid game type");
            }
        }
    }