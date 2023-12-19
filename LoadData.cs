using System.Collections.Generic;
using System.Windows.Forms;
using static WindowsFormsApp1.BookingHistoryData;
using static WindowsFormsApp1.TicketsData;
namespace WindowsFormsApp1
{
    public class LoadData
    {
        private TicketsData ticketData;
        private BookingHistoryData bookingHistoryData;

        public void LoadBookingHistoryData(DataGridView dataGridView)
        {
            bookingHistoryData = new BookingHistoryData();
            List<string> columns = bookingHistoryData.GetBookingHistoryColumns();
            List<BookingHistory> bookingHistory = bookingHistoryData.GetBookingHistoryData();

            dataGridView.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridView.Columns.Add(column, column);
            }

            foreach(var data in bookingHistory)
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
        public void LoadTrainTicketsData(DataGridView dataGridView)
        {
            ticketData = new TicketsData();
            List<string> columns = ticketData.GetTicketColumns();
            List<Ticket> trainTicketsData = ticketData.GetTicketData();

            dataGridView.Columns.Clear();
            foreach (var column in columns)
            {
                dataGridView.Columns.Add(column, column);
            }

            foreach (var data in trainTicketsData)
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
    }
}
