using Lab1.Lab1_architecture_with_server.Account;
using Lab1.Lab1_architecture_with_server.Game;

namespace Lab1.Lab1_architecture_with_server;

public class Server
{
    private long _gameId = 100000000;
    private long _accountId = 100000000;
    private readonly List<AbstractGame> _games = new();
    private readonly List<BaseAccount> _gameAccounts = new();
    private readonly Queue<BaseAccount> _gameAccountsQueueForStandardGame = new();
    private readonly Queue<BaseAccount> _gameAccountsQueueForTrainGame = new();
    
    public BaseAccount CreateBaseAccount(string name)
    {
        var account = new BaseAccount(name, this, _accountId++);
        _gameAccounts.Add(account);
        return account;
    }
    
    public BaseAccount CreateVipAccount(string name)
    {
        var account = new VipAccount(name, this, _accountId++);
        _gameAccounts.Add(account);
        return account;
    }
    
    public BaseAccount CreatePremiumAccount(string name)
    {
        var account = new PremiumAccount(name, this, _accountId++);
        _gameAccounts.Add(account);
        return account;
    }

    public void FindStandardGame(BaseAccount account)
    {
        if (_gameAccountsQueueForStandardGame.Contains(account) || _gameAccountsQueueForTrainGame.Contains(account))
        {
            throw new ArgumentException("You are already searching a game #findstgame!!!");
        }
        _gameAccountsQueueForStandardGame.Enqueue(account);
        CheckPlayersCountForStandardGame();
    }
    
    public void FindTrainGame(BaseAccount account)
    {
        if (_gameAccountsQueueForTrainGame.Contains(account) || _gameAccountsQueueForStandardGame.Contains(account))
        {
            throw new ArgumentException("You are already searching a game #findtraingame!!!");
        }
        _gameAccountsQueueForTrainGame.Enqueue(account);
        CheckPlayersCountForTrainGame();
    }

    private void CheckPlayersCountForStandardGame()
    {
        if (_gameAccountsQueueForStandardGame.Count != 2) return;
        var game = GameFactory.GetStandardGame(_gameAccountsQueueForStandardGame.Dequeue(), _gameAccountsQueueForStandardGame.Dequeue(), _gameId++);
        game.Play();
        _games.Add(game);
    }
    
    private void CheckPlayersCountForTrainGame()
    {
        if (_gameAccountsQueueForTrainGame.Count != 2) return;
        var game = GameFactory.GetTrainGame(_gameAccountsQueueForTrainGame.Dequeue(), _gameAccountsQueueForTrainGame.Dequeue(), _gameId++);
        game.Play();
        _games.Add(game);
    }

    public List<AbstractGame> GetAllGamesWithAccount(long index)
    {
        return _games.Where(game => game.WasInGame(index)).ToList();
    }

    public string AllAccounts()
    {
        var report = new System.Text.StringBuilder();
        foreach (var account in _gameAccounts)
        {
            report.Append(account.GetType() + " ");
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