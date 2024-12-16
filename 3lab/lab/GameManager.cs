using System;
using System.Collections.Generic;

public class GameManager
{
    /* ініціалізуємо змінні */
    private static DBcontext _context = new DBcontext(new List<GameResult>(), new List<GameAccount>()); /* міні бдшка */
    private static GameRepository _gameRepository = new GameRepository(_context.Games); /* працюємо з іграми  */
    private static GameAccountRepository _accountRepository = new GameAccountRepository(_context.Accounts);/* акаунти */
    private static GameService _gameService = new GameService(_gameRepository);/* управляємо іграми */
    private static AccountService _accountService = new AccountService(_accountRepository); /* акаунтами */

    
    private static Random random = new Random();


    public GameManager()
    {
        
    }

    public void SimulateGames(int numberOfGames, int id1, int id2, string gameType)
    {
        GameAccount player1 = _accountService.GetAccountByUserID(id1);
        GameAccount player2 = _accountService.GetAccountByUserID(id2);

        Console.WriteLine($"Історія ігор: {player1.UserName} проти {player2.UserName}");
        
        for (int i = 0; i < numberOfGames; i++)
        {
            GameAccount [] Players = new GameAccount[] {
                player1, player2
            };
            GameAccount playerWin = Players[random.Next(Players.Length)];

            if(playerWin.PlayerId == player1.PlayerId)
            
            {
                GameResult game = GameFactory.CreateGame(gameType, player1, player2, player1);
                _gameService.AddGame(game);
                player1.WinGame(game);
                player2.LoseGame(game);
                Console.WriteLine($"{player1.UserName} win");
            }
            else
            {
                GameResult game = GameFactory.CreateGame(gameType, player1, player2, player2);
                _gameService.AddGame(game);
                player1.LoseGame(game);
                player2.WinGame(game);
                Console.WriteLine($"{player2.UserName} win");
            }
            
        }
    }

public void CreateAccout(string name, string accountType)
    {
        GameAccount player;
        switch (accountType.ToLower())
        {
            case "standart":
                player = new StandartAccount(name);
                break;
            case "winstreak":
                player = new WinStreakAccount(name);
                break;
            case "losestreak":
                player = new LoseStreakAccount(name);
                break;
            default:
                throw new ArgumentException("Invalid account type");
        }
        _accountService.AddAccount(player);
    }

    public void DeleteAccount(int id)
    {
        GameAccount player = _accountService.GetAccountByUserID(id);
        _accountService.RemoveAccount(player);
    }

    public void PrintAccountStats()
    {
        List<GameAccount> Pudge = _accountService.GetAllAccounts();
        Console.WriteLine("Статистика гравців :");
        Console.WriteLine("ID Гравця\tНікнейм\t\tПоточний рейтинг\tКількість ігор");
        foreach (var player in Pudge)
        {
            Console.WriteLine($"{player.PlayerId,-10}\t{player.UserName,-10}\t{player.CurrentRating,-20}\t{player.GamesCount,-10}");
            Console.WriteLine();
        }
    }

    public void DeleteGame(int id)
    {
        GameResult game = _gameService.GetGamesByID(id);
        _gameService.RemoveGame(game);
    }

    public void UpdateGame(int id, string gameType, int UserId1, int UserId2, int WinnerId)
    {
        GameAccount player1 = _accountService.GetAccountByUserID(UserId1);
        GameAccount player2 = _accountService.GetAccountByUserID(UserId2);
        GameAccount winner = _accountService.GetAccountByUserID(WinnerId);
        GameResult game = GameFactory.CreateGame(gameType, player1, player2, winner);
        _gameService.UpdateGame(id, player1, player2, winner);
    }

    public void UpdatePlayer(int id, string username, int rating, int gamesCount)
    {
        _accountService.UpdateAccount(id, username, rating, gamesCount);
    }

    public void FindGamesByUserId(int id)
    {
        List<GameResult> gameResults = _gameService.GetGamesByUserID(id);
        Console.WriteLine("Індекси гри\tГравець\t\tПротивник\tПереможець\tРейтинг\tТип гри");
        foreach (var result in gameResults)
        {
            Console.WriteLine($"{result.GameIndex,-15}{result.Player.UserName,-15}{result.Opponent.UserName,-15}{result.Winner.UserName,-15}{result.RatingChange,-15}{result.GameType}");
        }
    }

    public void PrintGameResults()
    {
        List<GameResult> gameResults = _gameService.GetAllGames();
        Console.WriteLine("Індекси гри\tГравець\t\tПротивник\tПереможець\tРейтинг\tТип гри");
        foreach (var result in gameResults)
        {
            Console.WriteLine($"{result.GameIndex,-15}{result.Player.UserName,-15}{result.Opponent.UserName,-15}{result.Winner.UserName,-15}{result.RatingChange,-15}{result.GameType}");
        }
    }
}
