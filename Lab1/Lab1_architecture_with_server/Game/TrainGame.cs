using Lab1.Lab1_architecture_with_server.Account;

namespace Lab1.Lab1_architecture_with_server.Game;

public class TrainGame : AbstractGame
{
    private readonly long _index;
    private readonly BaseAccount _fplayer;
    private readonly BaseAccount _splayer;
    private readonly int _rating;
    private BaseAccount Winner { get; set; } = null!;
    private BaseAccount Loser { get; set; } = null!;

    public override void Play()
    {
        var random = new Random();
        var winner = random.Next(1, 3);
        if (winner == 1)
        {
            Winner = _fplayer;
            _fplayer.WinGame(this, _splayer.UserName);
            Loser = _splayer;
            _splayer.LoseGame(this, _fplayer.UserName);
        }
        else
        {
            Winner = _splayer;
            _splayer.WinGame(this, _fplayer.UserName);
            Loser = _fplayer;
            _fplayer.LoseGame(this, _splayer.UserName);
        }
    }

    public override string AsString()
    {
        var report = new System.Text.StringBuilder();
        report.Append("Training game winner - ");
        report.Append(Winner.UserName);
        // report.Append(' ');
        // report.Append(_winnerRating);
        report.Append(" vs ");
        // report.Append(_loserRating);
        // report.Append(' ');
        report.Append(Loser.UserName);
        report.Append(" - loser");
        report.Append(" gameId: " + _index);
        return report.ToString();
    }

    public TrainGame(BaseAccount fplayer, BaseAccount splayer, long index)
    {
        _fplayer = fplayer;
        _splayer = splayer;
        _index = index;
        _rating = 0;
    }
    
    public override bool WasInGame(long index)
    {
        return Winner.Index == index || Loser.Index == index;
    }

    public override int GetRating()
    {
        return _rating;
    }
}