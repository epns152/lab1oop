using Lab1.Lab1_architecture_with_server;

namespace Lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            // Server architecture
            
            // var server = new Server();
            // var fAccount = server.CreateAccount("Roman");
            // var sAccount = server.CreateAccount("Vitaliy");
            //
            // fAccount.FindGame();
            // sAccount.FindGame();
            //
            // sAccount.FindGame();
            // fAccount.FindGame();
            //
            // fAccount.GetStats();
            //
            // sAccount.FindGame();
            // fAccount.FindGame();
            //
            // sAccount.GetStats();
            
            // Decentralized architecture
            
            var me = new Lab1_decentralized_architecture.GameAccount("Roman");
            var enemy = new Lab1_decentralized_architecture.GameAccount("Vitaliy");
            
            me.WinGame(enemy, 100);
            me.WinGame(enemy, 100);
            me.LoseGame(enemy, 111);
            
            me.GetStats();
            enemy.GetStats();
        }
    }
}