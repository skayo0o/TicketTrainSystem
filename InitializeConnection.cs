using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public class InitializeConnection
    {
        private SQLiteConnection connection;

        public SQLiteConnection InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=TicketSystem.db";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
