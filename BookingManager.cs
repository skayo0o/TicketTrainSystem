using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using static WindowsFormsApp1.TicketsData;

namespace WindowsFormsApp1
{
    public class BookingManager
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;
        public void SearchTicketsByRouteAndDate(DataGridView dataGridView, List<Ticket> tickets, string pointOfDep, string pointOfArr, string depDate)
        {
            dataGridView.Rows.Clear();

            IEnumerable<Ticket> result = tickets.Where(ticket => ticket.PointOfDep == pointOfDep
                                            && ticket.PointOfArr == pointOfArr
                                            && ticket.DepDate == depDate);

            foreach (Ticket data in result)
            {
                object[] rowData = new object[data.GetType().GetProperties().Length];
                int index = 0;
                foreach (var prop in data.GetType().GetProperties())
                {
                    rowData[index] = prop.GetValue(data);
                    index++;
                }
                dataGridView.Rows.Add(rowData);
            }
        }

        public void SearchTicketsByRoute(DataGridView dataGridView, List<Ticket> tickets, string pointOfDep, string pointOfArr)
        {
            dataGridView.Rows.Clear();

            IEnumerable<Ticket> result = tickets.Where(ticket => ticket.PointOfDep == pointOfDep
                                            && ticket.PointOfArr == pointOfArr);
            foreach (Ticket data in result)
            {
                object[] rowData = new object[data.GetType().GetProperties().Length];
                int index = 0;
                foreach (var prop in data.GetType().GetProperties())
                {
                    rowData[index] = prop.GetValue(data);
                    index++;
                }
                dataGridView.Rows.Add(rowData);
            }
        }

        public void SearchTicketsByDeparture(DataGridView dataGridView, List<Ticket> tickets, string pointOfDep)
        {
            dataGridView.Rows.Clear();

            IEnumerable<Ticket> result = tickets.Where(ticket => ticket.PointOfDep == pointOfDep);
            foreach (Ticket data in result)
            {
                object[] rowData = new object[data.GetType().GetProperties().Length];
                int index = 0;
                foreach (var prop in data.GetType().GetProperties())
                {
                    rowData[index] = prop.GetValue(data);
                    index++;
                }
                dataGridView.Rows.Add(rowData);
            }
        }

        public void SearchTicketsByDepartureAndDate(DataGridView dataGridView, List<Ticket> tickets, string pointOfDep, string depDate)
        {
            dataGridView.Rows.Clear();

            IEnumerable<Ticket> result = tickets.Where(ticket => ticket.PointOfDep == pointOfDep
                                                            && ticket.DepDate == depDate);
            foreach (Ticket data in result)
            {
                object[] rowData = new object[data.GetType().GetProperties().Length];
                int index = 0;
                foreach (var prop in data.GetType().GetProperties())
                {
                    rowData[index] = prop.GetValue(data);
                    index++;
                }
                dataGridView.Rows.Add(rowData);
            }
        }

        public bool ReserveTickets(string fullName, string passport, int amount, string email, int availableTickets, int idRoute)
        {
            initConn = new InitializeConnection();
            connection = initConn.InitializeDatabaseConnection();

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Введите ФИО!");
                return false;
            }

            if (passport.Length > 6 && passport.Length < 6)
            {
                MessageBox.Show("Номер паспорта не должен превышать 6 символов!");
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите адрес электронной почты!");
                return false;
            }

            if (amount > availableTickets)
            {
                MessageBox.Show("Отсутствует указанное кол-во билетов на рейс!");
                return false;
            }

            if (amount < 1) 
            {
                MessageBox.Show("Кол-во билетов > 0!");
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
