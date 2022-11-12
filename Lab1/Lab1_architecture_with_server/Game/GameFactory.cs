using Lab1.Lab1_architecture_with_server.Account;

namespace Lab1.Lab1_architecture_with_server.Game;

public class GameFactory
{
    public static AbstractGame GetStandardGame(BaseAccount fplayer, BaseAccount splayer, long index)
    {
        return new StandardGame( fplayer, splayer, index);
    }

    public static AbstractGame GetTrainGame(BaseAccount fplayer, BaseAccount splayer, long index)
    {
        return new TrainGame( fplayer, splayer, index);
    }
}