using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class InitializeConnection
    {
        private SQLiteConnection connection;
        public InitializeConnection(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public SQLiteConnection InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=TicketSystem.db";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
