using System;
using System.Collections.Generic;

public class GameManager
{
    
    private static Random random = new Random();
    private List<GameResult> gameResults;

    public GameManager()
    {
        gameResults = new List<GameResult>();
    }

    public void SimulateGames(int numberOfGames, GameAccount player1, GameAccount player2, string gameType)
    {
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
                gameResults.Add(game);
                player1.WinGame(game);
                player2.LoseGame(game);
                Console.WriteLine($"{player1.UserName} win");
            }
            else
            {
                GameResult game = GameFactory.CreateGame(gameType, player1, player2, player2);
                gameResults.Add(game);
                player1.LoseGame(game);
                player2.WinGame(game);
                Console.WriteLine($"{player2.UserName} win");
            }
            
        }
    }

    public void PrintGameResults()
    {
        Console.WriteLine("Індекси гри\tГравець\t\tПротивник\tПереможець\tРейтинг\tТип гри");
        foreach (var result in gameResults)
        {
            Console.WriteLine($"{result.GameIndex,-15}{result.Player,-15}{result.Opponent,-15}{result.Winner,-15}{result.RatingChange,-15}{result.GameType}");
        }
    }
}
