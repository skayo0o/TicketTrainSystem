using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class LoadData
    {
        private SQLiteConnection connection;
        private SQLiteDataAdapter dataAdapter;
        private DataTable dataTable;
        private InitializeConnection initConn;

        public void LoadBookingHistoryData(DataGridView dataGridView)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM BookingHistory";

            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;
        }
        public void LoadTrainTicketsData(DataGridView dataGridView)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets";

            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;
        }
    }
}
