namespace Lab1.Lab1_architecture_with_server;

public class GameForAccountStats
{
    private readonly string _opponentName;
    private readonly int _rating;
    private readonly string _outcome;
    private static int _index = 1000000;
    private readonly int _id;

    public GameForAccountStats(string opponentName, int rating, string outcome)
    {
        this._opponentName = opponentName;
        this._outcome = outcome;
        this._rating = rating;
        this._id = _index++;
    }

    public override string ToString()
    {
        var report = new System.Text.StringBuilder();
        report.Append("Outcome - " + _outcome);
        report.Append("\trating - " + _rating);
        report.Append("\topponent - " + _opponentName);
        report.Append("\tid - " + _id);
        return report.ToString();
    }
}