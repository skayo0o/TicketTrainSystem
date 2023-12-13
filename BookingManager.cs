using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BookingManager
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;
        public DataTable CreateDataAdapter(SQLiteCommand command)
        {
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable SearchTicketsByRouteAndDate(string pointOfDep, string pointOfArr, string depDate)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets WHERE PointOfDep = @PointOfDep AND PointOfArr = @PointOfArr AND DepDate = @DepDate";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@PointOfDep", pointOfDep);
            command.Parameters.AddWithValue("@PointOfArr", pointOfArr);
            command.Parameters.AddWithValue("@DepDate", depDate);

            return CreateDataAdapter(command);
        }

        public DataTable SearchTicketsByRoute(string pointOfDep, string pointOfArr)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets WHERE PointOfDep = @PointOfDep AND PointOfArr = @PointOfArr";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@PointOfDep", pointOfDep);
            command.Parameters.AddWithValue("@PointOfArr", pointOfArr);

            return CreateDataAdapter(command);
        }

        public DataTable SearchTicketsByDeparture(string pointOfDep)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets WHERE PointOfDep = @PointOfDep";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@PointOfDep", pointOfDep);

            return CreateDataAdapter(command);
        }

        public DataTable SearchTicketsByDepartureAndDate(string pointOfDep, string depDate)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string query = "SELECT * FROM Tickets WHERE PointOfDep = @PointOfDep AND DepDate = @DepDate";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@PointOfDep", pointOfDep);
            command.Parameters.AddWithValue("@DepDate", depDate);

            return CreateDataAdapter(command);
        }

        public bool ReserveTickets(string fullName, string passport, int amount, string email)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Введите ФИО!");
                return false;
            }

            if (passport.Length > 6)
            {
                MessageBox.Show("Номер паспорта не должен превышать 6 символов!");
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите адрес электронной почты!");
                return false;
            }

            int selectedRowIndex = ((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.SelectedCells[0].RowIndex;
            int idRoute = Convert.ToInt32(((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.Rows[selectedRowIndex].Cells["IDRoute"].Value);

            int availableTickets = Convert.ToInt32(((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.Rows[selectedRowIndex].Cells["Seats"].Value);

            if (amount > availableTickets)
            {
                MessageBox.Show("Отсутствует указанное кол-во билетов на рейс!");
                return false;
            }

            string query = "INSERT INTO BookingHistory (IDRoute, FullName, Passport, Amount) VALUES (@IDRoute, @FullName, @Passport, @Amount)";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@IDRoute", idRoute);
            command.Parameters.AddWithValue("@FullName", fullName);
            command.Parameters.AddWithValue("@Passport", passport);
            command.Parameters.AddWithValue("@Amount", amount);

            command.ExecuteNonQuery();

            string updateQuery = "UPDATE Tickets SET Seats = Seats - @Amount WHERE IDRoute = @IDRoute";

            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@Amount", amount);
            updateCommand.Parameters.AddWithValue("@IDRoute", idRoute);

            updateCommand.ExecuteNonQuery();

            return true;
        }
    }
}
