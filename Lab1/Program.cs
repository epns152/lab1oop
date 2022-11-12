using Lab1.Lab1_architecture_with_server;
using Lab1.Lab1_decentralized_architecture;
using Game = Lab1.Lab1_decentralized_architecture.Game;
using GameAccount = Lab1.Lab1_decentralized_architecture.GameAccount;

namespace Lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            // Server architecture
            
            var server = new Server();
            var fAccount = server.CreateVipAccount("Roman");
            var sAccount = server.CreatePremiumAccount("Vitaliy");
            
            fAccount.FindStandardGame();
            sAccount.FindStandardGame();
            
            sAccount.FindStandardGame();
            fAccount.FindStandardGame();
            
            sAccount.FindTrainGame();
            fAccount.FindTrainGame();
            
            sAccount.FindStandardGame();
            fAccount.FindStandardGame();

            sAccount.FindStandardGame();
            fAccount.FindStandardGame();

            sAccount.GetStatsFromServer();
            fAccount.GetStatsFromServer();
            
            // Console.WriteLine(server.AllAccounts());
            
        }
    }
}