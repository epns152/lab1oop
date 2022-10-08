
namespace Lab1.Lab1_architecture_with_server;

public class Game
{
    private readonly long _index;
    private readonly GameAccount _fplayer;
    private readonly GameAccount _splayer;
    private int rating;
    private int _winnerRating;
    private int _loserRating;
    private GameAccount Winner { get; set; } = null!;
    private GameAccount Loser { get; set; } = null!;


    public Game(GameAccount fplayer, GameAccount splayer, long index)
    {
        _fplayer = fplayer;
        _splayer = splayer;
        _index = index;
        rating = 30 + Math.Abs(fplayer.CurrentRating - splayer.CurrentRating) / 20;
    }

    public void Play()
    {
        var random = new Random();
        var winner = random.Next(1, 3);
        if (winner == 1)
        {
            _winnerRating = _fplayer.CurrentRating;
            _loserRating = _splayer.CurrentRating;
            Winner = _fplayer;
            _fplayer.WinGame(rating, _splayer.UserName);
            Loser = _splayer;
            _splayer.LoseGame(rating, _fplayer.UserName);
        }
        else
        {
            _winnerRating = _splayer.CurrentRating;
            _loserRating = _fplayer.CurrentRating;
            Winner = _splayer;
            _splayer.WinGame(rating, _fplayer.UserName);
            Loser = _fplayer;
            _fplayer.LoseGame(rating, _splayer.UserName);
        }
    }

    public string AsString()
    {
        var report = new System.Text.StringBuilder();
        report.Append("winner - ");
        report.Append(Winner.UserName);
        report.Append(' ');
        report.Append(_winnerRating);
        report.Append(" vs ");
        report.Append(_loserRating);
        report.Append(' ');
        report.Append(Loser.UserName);
        report.Append(" - loser");
        report.Append(" gameId: " + _index);
        return report.ToString();
    }

    public bool WasInGame(long index)
    {
        return Winner.Index == index || Loser.Index == index;
    }
}


