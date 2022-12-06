using Lab1.Lab1_architecture_with_server.Game;

namespace Lab1.Lab1_architecture_with_server.Account;

public class PremiumAccount : VipAccount
{
    private bool _previousGame = false;
    
    public PremiumAccount(string userName, Server server, long index) : base(userName, server, index)
    {
        UserName = userName;
        CurrentRating = 1000;
        GamesCount = 0;
        Server = server;
        Index = index;
    }
    
    public override void LoseGame(AbstractGame game, string opponentName)
    {
        var rating = game.GetRating();
        rating /= 2;
        if (rating < 0)
        {
            throw new ArgumentException("Rating cannot be less than 0");
        }
        GamesCount++;
        if (CurrentRating <= 10) return;
        CurrentRating -= rating;
        if (CurrentRating < 10)
        {
            CurrentRating = 10;
        }
        MyGames.Add(new GameForAccountStats(opponentName, rating, "lose"));
        _previousGame = false;
    }
    
    public override void WinGame(AbstractGame game, string opponentName)
    {
        var rating = game.GetRating();
        if (_previousGame)
        {
            rating *= 2;
        }

        if (rating < 0)
        {
            throw new ArgumentException("Rating cannot be less than 0");
        }

        GamesCount++;
        CurrentRating += rating;
        MyGames.Add(new GameForAccountStats(opponentName, rating, "win"));
        _previousGame = true;
    }
    
    public override void GetStatsFromServer()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Premium Name: " + UserName);
        report.AppendLine("Total games played: " + GamesCount);
        report.AppendLine("Rating: " + CurrentRating);
        report.AppendLine("Games:");
        var games = Server.GetAllGamesWithAccount(Index);
        foreach (var game in games)
        {
            report.AppendLine(game.AsString());
        }
        Console.WriteLine(report.ToString());
    }
}