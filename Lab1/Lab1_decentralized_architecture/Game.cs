namespace Lab1.Lab1_decentralized_architecture;

public class Game
{
    private readonly long _index;
    private static long _id = 100000000;
    
    private readonly int _rating;
    private GameAccount Winner { get; set; }
    private GameAccount Loser { get; set; }


    public Game(GameAccount winner, GameAccount loser, int rating)
    {
        Winner = winner;
        Loser = loser;
        this._rating = rating;
        _index = _id++;
    }

    public string AsString()
    {
        var report = new System.Text.StringBuilder();
        report.Append("winner - ");
        report.Append(Winner.UserName);
        report.Append(" vs ");
        report.Append(Loser.UserName);
        report.Append(" - loser");
        report.Append(" rating: ");
        report.Append(_rating);
        report.Append(" gameId: " + _index);
        return report.ToString();
    }
}


