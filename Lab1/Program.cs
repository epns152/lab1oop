using Lab1.Lab1_architecture_with_server;

namespace Lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            // Server architecture
            
            var server = new Server();
            var fAccount = server.CreateAccount("Roman");
            var sAccount = server.CreateAccount("Vitaliy");
            
            fAccount.FindGame();
            sAccount.FindGame();
            
            sAccount.FindGame();
            fAccount.FindGame();
            
            // fAccount.GetStatsFromServer();
            
            sAccount.FindGame();
            fAccount.FindGame();
            
            sAccount.GetStatsFromServer();
            fAccount.GetStatsFromAccount();
        }
    }
}