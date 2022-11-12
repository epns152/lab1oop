namespace Lab1.Lab1_architecture_with_server.Account;

public class BaseAccount
{
    public string UserName { get; protected init; }
    public int CurrentRating { get; protected set; }
    protected int GamesCount;
    protected Server Server;
    public long Index;
    protected readonly List<GameForAccountStats> MyGames = new();

    public BaseAccount(string userName, Server server, long index)
    {
        UserName = userName;
        CurrentRating = 1000;
        GamesCount = 0;
        Server = server;
        Index = index;
    }

    public virtual void LoseGame(AbstractGame game, string opponentName)
    {
        int rating;
        if ((rating = game.GetRating()) < 0)
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
    
    public virtual void WinGame(AbstractGame game, string opponentName)
    {
        int rating;
        if ((rating = game.GetRating()) < 0)
        {
            throw new ArgumentException("Rating cannot be less than 0");
        }
        GamesCount++;
        CurrentRating += rating;
        MyGames.Add(new GameForAccountStats(opponentName, rating, "win"));
    }

    public void FindStandardGame()
    {
        try
        {
            Server.FindStandardGame(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Can't start search, because you are already in search: " + e.Message);
        }
    }
    
    public void FindTrainGame()
    {
        try
        {
            Server.FindTrainGame(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Can't start search, because you are already in search", e);
        }
    }

    public virtual void GetStatsFromServer()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Name: " + UserName);
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
    
    public void GetStatsFromAccount()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Name: " + UserName);
        report.AppendLine("Total games played: " + GamesCount);
        report.AppendLine("Rating: " + CurrentRating);
        report.AppendLine("Games:");
        foreach (var game in MyGames)
        {
            report.AppendLine(game.ToString());
        }
        Console.WriteLine(report.ToString());
    }
}