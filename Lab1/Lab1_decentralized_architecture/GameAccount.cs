namespace Lab1.Lab1_decentralized_architecture;

public class GameAccount
{
    public string UserName { get; }
    private int CurrentRating { get; set; }
    private int _gamesCount;
    private readonly List<Game> _games = new();
    private readonly long _index;
    private static long _id = 100000000;

    public GameAccount(string userName)
    {
        UserName = userName;
        CurrentRating = 1000;
        _gamesCount = 0;
        _index = _id++;
    }

    public void LoseGame(GameAccount enemy, int rating)
    {
        if (rating <= 0)
        {
            throw new ArgumentException("Rating cannot be less than 1");
        }
        if (enemy == this)
        {
            throw new ArgumentException("You cannot play with yourself");
        }

        _gamesCount++;
        enemy._gamesCount++;
        CurrentRating -= rating;
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }
        
        enemy.CurrentRating += rating;

        var game = new Game(enemy, this, rating);
        _games.Add(game);
        enemy._games.Add(game);
    }
    
    public void WinGame(GameAccount enemy, int rating)
    {
        if (rating <= 0)
        {
            throw new ArgumentException("Rating cannot be less than 1");
        }
        if (enemy == this)
        {
            throw new ArgumentException("You cannot play with yourself");
        }

        _gamesCount++;
        enemy._gamesCount++;
        CurrentRating += rating;

        enemy.CurrentRating -= rating;
        if (enemy.CurrentRating < 1)
        {
            enemy.CurrentRating = 1;
        }

        var game = new Game(this, enemy, rating);
        _games.Add(game);
        enemy._games.Add(game);
    }
    

    public void GetStats()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Name: " + UserName);
        report.AppendLine("Total games played: " + _gamesCount);
        report.AppendLine("Rating: " + CurrentRating);
        report.AppendLine("Id: " + _index);
        report.AppendLine("Games:");
        foreach (var game in _games)
        {
            report.AppendLine(game.AsString());
        }
        Console.WriteLine(report.ToString());
    }
}