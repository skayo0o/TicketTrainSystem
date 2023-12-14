using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class LoadData
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;

        public void LoadBookingHistoryData(DataGridView dataGridView)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM BookingHistory";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                dataGridView.Columns.Clear();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView.Rows.Add(rowData);
                }
            }
        }
        public void LoadTrainTicketsData(DataGridView dataGridView)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                dataGridView.Columns.Clear();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView.Rows.Add(rowData);
                }
            }
        }
    }
}
