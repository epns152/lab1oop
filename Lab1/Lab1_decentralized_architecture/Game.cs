namespace Lab1.Lab1_decentralized_architecture;

public class Game
{
    private readonly long _index;
    private static long _id = 100000000;
    
    private readonly int _rating;
    private GameAccount Winner { get; }
    private GameAccount Loser { get; }


    public Game(GameAccount winner, GameAccount loser, int rating)
    {
        Winner = winner;
        Loser = loser;
        _rating = rating;
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
    
    public static void Play(int rating, GameAccount sAccount, GameAccount fAccount)
    {
        var random = new Random();
        var winner = random.Next(1, 3);
        try
        {
            if (winner == 1)
            {
                sAccount.WinGame(fAccount, rating);
            }
            else
            {
                sAccount.LoseGame(fAccount, rating);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message + "\n");
        }
    }
}


