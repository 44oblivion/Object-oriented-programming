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
    private static GameAccount bot = new Bot("bot", "1234"); /* бот */

    private static Random random = new Random();

    public GameManager()
    {

    }

    public void SimulateGames(string gameType)
    {
        char[,] board = new char[3, 3]; 
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' ';

        GameAccount player = UserSession.currentUser;
        GameAccount opponent = bot;
        char currentPlayer = 'X';
        bool gameWon = false;

        while (!gameWon && !IsBoardFull(board))
        {
            PrintBoard(board);
            if (currentPlayer == 'X')
            {
                bool validMove = false;
                while (!validMove)
                {
                    Console.WriteLine("Ваш хід\nВведіть номер рядка (0-2) та номер стовпчика (0-2), розділені пробілом:");
                    string[] input = Console.ReadLine().Split(' ');

                    if (input.Length == 2 
                        && int.TryParse(input[0], out int row) // якщо інт то в роу
                        && int.TryParse(input[1], out int col) // якщо інт то в кол
                        && row >= 0 && row < 3 // роу від 0 до 3
                        && col >= 0 && col < 3) // роу від 0 до 3
                    {
                        if (board[row, col] == ' ')
                        {
                            board[row, col] = 'X';
                            currentPlayer = 'O';
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Це поле вже зайняте");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильний хід спробуйте ще раз");
                    }
                }
            }
            else
            {
                Console.WriteLine("Хід бота...");
                bool moved = false;
                while (!moved)
                {
                    int row = random.Next(3);
                    int col = random.Next(3);
                    if (board[row, col] == ' ')
                    {
                        board[row, col] = 'O';
                        moved = true;
                        currentPlayer = 'X';
                    }
                }
            }

            gameWon = CheckWin(board);
        }

        PrintBoard(board);

        if (gameWon)
        {
            if (currentPlayer == 'O')
            {
                Console.WriteLine("Ви перемогли!");
                GameResult game = GameFactory.CreateGame(gameType, player, opponent, player);
                _gameService.AddGame(game);
                player.WinGame(game);
                opponent.LoseGame(game);
            }
            else
            {
                Console.WriteLine("Бот переміг!");
                GameResult game = GameFactory.CreateGame(gameType, player, opponent, opponent);
                _gameService.AddGame(game);
                player.LoseGame(game);
                opponent.WinGame(game);
            }
        }
        else
        {
                Console.WriteLine("Нічия!");
                GameResult game = GameFactory.CreateGame(gameType, player, opponent, null);
                _gameService.AddGame(game);
                player.DrawGame(game);
                opponent.DrawGame(game);
        }
    }

    private void PrintBoard(char[,] board)
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    private bool IsBoardFull(char[,] board)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i, j] == ' ')
                    return false;
        return true;
    }

    private bool CheckWin(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
            if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return true;
        }
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;
        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }

    
    public void CreateAccount(string name, string accountType, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Ім'я не може бути порожнім.");
        }

        else if (name.Contains(" "))
        {
            Console.WriteLine("Ім'я не може містити пробіли.");
        }

        else if (CheckValidUsername(name))
        {
            Console.WriteLine("Користувач з таким ім'ям вже існує");
        }
        else
        {
            GameAccount player = FabricPlayer.CreateAccount(name, accountType, password);
            _accountService.AddAccount(player);
        }
    }

    public bool CheckValidUsername(string username)
    {
        if (_accountService.GetByUserName(username) != null)
        {
            return true;
        }
        else{
            return false;
        }
    }
    

    public void UpdatePlayer(string newUsername)
    {
        if(CheckValidUsername(newUsername))
        {
            Console.WriteLine("Користувач з таким ім'ям вже існує");
        }else{
        int id = UserSession.currentUser.PlayerId;
        _accountService.UpdateAccount(id, newUsername);
        }
        
    }


    public void DeleteAccount()
    {
        _accountService.RemoveAccount(UserSession.currentUser);
    }

    public void Login(string username, string password)
    {
        if (_accountService.Login(username, password))
        {
            Console.WriteLine("Ви увійшли в систему");
        }
        else
        {
            Console.WriteLine("Неправильний логін або пароль");
        }
    }



    public void Logout()
    {
        _accountService.Logout();
    }

    public void FindAccountByUserName(string userName)
    {
        if(CheckValidUsername(userName))
        {
            GameAccount player = _accountService.GetByUserName(userName);
            Console.WriteLine($"Індекс гравця\tГравець\tРейтинг\tКількість ігор");
            Console.WriteLine($"{player.PlayerId,-15}\t{player.UserName}\t{player.CurrentRating}\t{player.GamesCount}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Користувача з таким ім'ям не існує");
        }
    }


    public void PrintCurrentUserProfile()
    {
        GameAccount player = _accountService.CurrentUserProfile();
        Console.WriteLine($"Статистика гравця {player.UserName}:");
        Console.WriteLine("Індекси гравця\tГравець\tРейтинг\tКількість ігор");
        Console.WriteLine($"{player.PlayerId,-15}\t{player.UserName}\t{player.CurrentRating}\t{player.GamesCount}");
        Console.WriteLine();
    }




    public void GetAccountGameHistory()
    {
        GameAccount player = UserSession.currentUser;
        List<GameResult> gameResults = _gameService.GetGamesByPlayer(player);
        Console.WriteLine($"Історія ігор гравця {player.UserName}:");
        Console.WriteLine("Індекси гри\tГравець\tПротивник\tПереможець\tРейтинг\tТип гри");
        foreach (var result in gameResults)
        {
            string winnerName = result.Winner != null ? result.Winner.UserName : "Нічия";
            Console.WriteLine($"{result.GameIndex,-16}{result.Player.UserName,-16}{result.Opponent.UserName,-16}{winnerName,-16}{result.RatingChange,-8}{result.GameType}");
        }
    }


    public void PrintGameResults()
    {
        List<GameResult> gameResults = _gameService.GetAllGames();
        Console.WriteLine("Індекси гри\tГравець\t\tПротивник\tПереможець\tРейтинг\tТип гри");
        foreach (var result in gameResults)
        {
            Console.WriteLine($"{result.GameIndex,-16}{result.Player.UserName,-16}{result.Opponent.UserName,-16}{result.Winner.UserName,-16}{result.RatingChange,-8}{result.GameType}");
        }
    }
}
