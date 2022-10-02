namespace Lab1.Lab1_architecture_with_server;

public class GameAccount
{
    public string UserName { get; }
    public int CurrentRating { get; private set; }
    private int _gamesCount;
    private readonly Server _server;
    public readonly long Index;

    public GameAccount(string userName, Server server, long index)
    {
        UserName = userName;
        CurrentRating = 1000;
        _gamesCount = 0;
        _server = server;
        Index = index;
    }

    public void LoseGame()
    {
        _gamesCount++;
        if (CurrentRating <= 10) return;
        CurrentRating -= 30;
        if (CurrentRating < 10)
        {
            CurrentRating = 10;
        }
    }
    
    public void WinGame()
    {
        _gamesCount++;
        CurrentRating += 30;
    }

    public void FindGame()
    {
        try
        {
            _server.FindGame(this);
        }
        catch (Exception e)
        {
            Console.WriteLine("Can't start search, because you are already in search");
        }
    }

    public void GetStats()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Name: " + UserName);
        report.AppendLine("Total games played: " + _gamesCount);
        report.AppendLine("Rating: " + CurrentRating);
        report.AppendLine("Games:");
        var games = _server.GetAllGamesWithAccount(Index);
        foreach (var game in games)
        {
            report.AppendLine(game.AsString());
        }
        Console.WriteLine(report.ToString());
    }
}