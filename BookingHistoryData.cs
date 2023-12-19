using System.Collections.Generic;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public class BookingHistoryData
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;

        public class BookingHistory
        {
            public int IDBooking { get; set; }
            public int IDRoute { get; set; }
            public string FullName { get; set; }
            public string Passport { get; set; }
            public decimal Amount { get; set; }
        }

        public List<string> GetBookingHistoryColumns()
        {
            List<string> columns = new List<string>();
            initConn = new InitializeConnection();
            connection = initConn.InitializeDatabaseConnection();

            string query = "PRAGMA table_info(BookingHistory)";
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

        public List<BookingHistory> GetBookingHistoryData()
        {
            List<BookingHistory> bookingHistory = new List<BookingHistory>();
            initConn = new InitializeConnection();
            connection = initConn.InitializeDatabaseConnection();

            string query = "SELECT * FROM BookingHistory";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BookingHistory history = new BookingHistory
                        {
                            IDBooking = reader.GetInt32(0),
                            IDRoute = reader.GetInt32(1),
                            FullName = reader.GetString(2),
                            Passport = reader.GetString(3),
                            Amount = reader.GetDecimal(4)
                        };
                        bookingHistory.Add(history);
                    }
                }
            }

            return bookingHistory;
        }
    }
}
