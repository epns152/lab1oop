namespace Lab1.Lab1_architecture_with_server;

public class AccountGame
{
    private readonly string _opponentName;
    private readonly int _rating;
    private readonly string _outcome;
    private static int _index = 1000000;
    private readonly int _id;

    public AccountGame(string opponentName, int rating, string outcome)
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
        report.Append(" rating - " + _rating);
        report.Append(" opponent - " + _opponentName);
        report.Append("\nid - " + _id);
        return report.ToString();
    }
}