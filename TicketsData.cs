using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class TicketsData
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;
        public class Ticket
        {
            public int ID_Route { get; set; }
            public string PointOfDep { get; set; }
            public string PointOfArr { get; set; }
            public string DepDate { get; set; }
            public string DepTime { get; set; }
            public string ArrDate { get; set; }
            public string ArrTime { get; set; }
            public int Seats { get; set; }
        }
        public List<Ticket> GetTicketData()
        {
            List<Ticket> tickets = new List<Ticket>();
            initConn = new InitializeConnection();
            connection = initConn.InitializeDatabaseConnection();

            string query = "SELECT * FROM Tickets";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            ID_Route = reader.GetInt32(0),
                            PointOfDep = reader.GetString(1),
                            PointOfArr = reader.GetString(2),
                            DepDate = reader.GetString(3),
                            DepTime = reader.GetString(4),
                            ArrDate = reader.GetString(5),
                            ArrTime = reader.GetString(6),
                            Seats = reader.GetInt32(7)
                        };
                        tickets.Add(ticket);
                    }
                }
            }


            return tickets;
        }
        public List<string> GetTicketColumns()
        {
            List<string> columns = new List<string>();
            initConn = new InitializeConnection();
            connection = initConn.InitializeDatabaseConnection();

            string query = "PRAGMA table_info(Tickets)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(1);
                        columns.Add(columnName);
                    }
                }
            }

            return columns;
        }
        public List<Ticket> ReadTicketsFromDataGridView(DataGridView dataGridView)
        {
            List<Ticket> tickets = new List<Ticket>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                Ticket ticket = new Ticket
                {
                    ID_Route = Convert.ToInt32(row.Cells["IDRoute"].Value),
                    PointOfDep = Convert.ToString(row.Cells["PointOfDep"].Value),
                    PointOfArr = Convert.ToString(row.Cells["PointOfArr"].Value),
                    DepDate = Convert.ToString(row.Cells["DepDate"].Value),
                    DepTime = Convert.ToString(row.Cells["DepTime"].Value),
                    ArrDate = Convert.ToString(row.Cells["ArrDate"].Value),
                    ArrTime = Convert.ToString(row.Cells["ArrTime"].Value),
                    Seats = Convert.ToInt32(row.Cells["Seats"].Value)
                };
                tickets.Add(ticket);
            }

            return tickets;
        }
    }
}
