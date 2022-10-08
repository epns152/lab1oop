namespace Lab1.Lab1_architecture_with_server;

public class GameAccount
{
    public string UserName { get; }
    public int CurrentRating { get; private set; }
    private int _gamesCount;
    private readonly Server _server;
    public readonly long Index;
    private readonly List<AccountGame> _myGames = new();

    public GameAccount(string userName, Server server, long index)
    {
        UserName = userName;
        CurrentRating = 1000;
        _gamesCount = 0;
        _server = server;
        Index = index;
    }

    public void LoseGame(int rating, string opponentName)
    {
        _gamesCount++;
        if (CurrentRating <= 10) return;
        CurrentRating -= rating;
        if (CurrentRating < 10)
        {
            CurrentRating = 10;
        }
        _myGames.Add(new AccountGame(opponentName, rating, "lose"));
    }
    
    public void WinGame(int rating, string opponentName)
    {
        _gamesCount++;
        CurrentRating += rating;
        _myGames.Add(new AccountGame(opponentName, rating, "win"));
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

    public void GetStatsFromServer()
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
    
    public void GetStatsFromAccount()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Name: " + UserName);
        report.AppendLine("Total games played: " + _gamesCount);
        report.AppendLine("Rating: " + CurrentRating);
        report.AppendLine("Games:");
        foreach (var game in _myGames)
        {
            report.AppendLine(game.ToString());
        }
        Console.WriteLine(report.ToString());
    }
}