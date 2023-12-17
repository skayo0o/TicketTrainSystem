using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<DataGridViewRow> SearchTicketsByRouteAndDate(DataGridView dataGridView, string pointOfDep, string pointOfArr, string depDate)
        {
            return dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToString(row.Cells["PointOfDep"].Value) == pointOfDep
                    && Convert.ToString(row.Cells["PointOfArr"].Value) == pointOfArr
                    && Convert.ToString(row.Cells["DepDate"].Value) == depDate);
        }

        public IEnumerable<DataGridViewRow> SearchTicketsByRoute(DataGridView dataGridView, string pointOfDep, string pointOfArr)
        {
            return dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToString(row.Cells["PointOfDep"].Value) == pointOfDep
                    && Convert.ToString(row.Cells["PointOfArr"].Value) == pointOfArr);
        }

        public IEnumerable<DataGridViewRow> SearchTicketsByDeparture(DataGridView dataGridView, string pointOfDep)
        {
            return dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToString(row.Cells["PointOfDep"].Value) == pointOfDep);
        }

        public IEnumerable<DataGridViewRow> SearchTicketsByDepartureAndDate(DataGridView dataGridView, string pointOfDep, string depDate)
        {
            return dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToString(row.Cells["PointOfDep"].Value) == pointOfDep
                    && Convert.ToString(row.Cells["DepDate"].Value) == depDate);
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
