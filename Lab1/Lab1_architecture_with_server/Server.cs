namespace Lab1.Lab1_architecture_with_server;

public class Server
{
    private long _gameId = 100000000;
    private long _accountId = 100000000;
    private readonly List<Game> _games = new();
    private readonly List<GameAccount> _gameAccounts = new();
    private readonly Queue<GameAccount> _gameAccountsQueue = new();
    
    public GameAccount CreateAccount(string name)
    {
        var account = new GameAccount(name, this, _accountId++);
        _gameAccounts.Add(account);
        return account;
    }

    public void FindGame(GameAccount account)
    {
        if (_gameAccountsQueue.Contains(account))
        {
            throw new ArgumentException("You are already searching a game!!!");
        }
        _gameAccountsQueue.Enqueue(account);
        CheckPlayersCount();
    }

    private void CheckPlayersCount()
    {
        if (_gameAccountsQueue.Count != 2) return;
        var game = new Game(_gameAccountsQueue.Dequeue(), _gameAccountsQueue.Dequeue(), _gameId++);
        game.Play();
        _games.Add(game);
    }

    public List<Game> GetAllGamesWithAccount(long index)
    {
        return _games.Where(game => game.WasInGame(index)).ToList();
    }

    public string AllAccounts()
    {
        var report = new System.Text.StringBuilder();
        foreach (var account in _gameAccounts)
        {
            report.Append("Name: ");
            report.Append(account.UserName);
            report.Append('\n');
            report.Append("Rating: ");
            report.Append(account.CurrentRating);
            report.Append('\n');
            report.Append('\n');
        }
        return report.ToString();
    }
}