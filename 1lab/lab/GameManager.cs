using System;
using System.Collections.Generic;

public class GameManager
{
    private GameAccount[] players;
    private static Random random = new Random();
    private List<GameResult> gameResults;

    public GameManager(GameAccount[] players)
    {
        this.players = players;
        gameResults = new List<GameResult>();
    }

    public void SimulateGames(int numberOfGames)
    {
        for (int i = 0; i < numberOfGames; i++)
        {
            int player1Index = random.Next(players.Length);
            int player2Index;
            do
            {
                player2Index = random.Next(players.Length);
            } while (player1Index == player2Index);

            string winner;
            int ratingChange;

            if (random.Next(2) == 0)
            {
                winner = players[player1Index].UserName;
                ratingChange = random.Next(1, 31);
                players[player1Index].WinGame(players[player2Index].UserName);
                players[player2Index].LoseGame(players[player1Index].UserName);
            }
            else
            {
                winner = players[player2Index].UserName;
                ratingChange = random.Next(1, 31);
                players[player2Index].WinGame(players[player1Index].UserName);
                players[player1Index].LoseGame(players[player2Index].UserName);
            }

            gameResults.Add(new GameResult(players[player1Index].UserName, players[player2Index].UserName, winner, ratingChange));
        }
    }

    public void PrintGameResults()
    {
        Console.WriteLine("Game Index\tPlayer\t\tOpponent\tWinner\t\tRating Change");
        foreach (var result in gameResults)
        {
            Console.WriteLine($"{result.GameIndex,-12}{result.Player,-15}{result.Opponent,-15}{result.Winner,-15}{result.RatingChange}");
        }
    }
}
