
using Lab1.Lab1_architecture_with_server.Account;

namespace Lab1.Lab1_architecture_with_server;

public abstract class AbstractGame
{
    public abstract void Play();

    public abstract string AsString();

    public abstract bool WasInGame(long index);

    public abstract int GetRating();
}


