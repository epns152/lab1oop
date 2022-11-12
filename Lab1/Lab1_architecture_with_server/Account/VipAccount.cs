namespace Lab1.Lab1_architecture_with_server.Account;

public class VipAccount : BaseAccount
{
    public VipAccount(string userName, Server server, long index) : base(userName, server, index)
    {
        UserName = userName;
        CurrentRating = 1000;
        GamesCount = 0;
        server = Server;
        index = Index;
    }
    
    public override void LoseGame(AbstractGame game, string opponentName)
    {
        int rating = game.GetRating();
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
    }
    
    public override void GetStatsFromServer()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Vip Name: " + UserName);
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