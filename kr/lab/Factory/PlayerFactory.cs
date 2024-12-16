static class FabricPlayer{

            public static GameAccount CreateAccount(string name, string accountType, string password)
            {
                switch (accountType.ToLower())
                {
            case "standart":
                return new StandartAccount(name, password);
            case "winstreak":
                return new WinStreakAccount(name, password);
            case "losestreak":
                return new LoseStreakAccount(name, password);
            
            default:
                throw new ArgumentException("Invalid account type");
        }

    }
}