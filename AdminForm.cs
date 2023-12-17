using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        private LoadData loadData;
        private SQLiteConnection connection;
        private InitializeConnection initConn;
        private string TableName;

        public AdminForm()
        {
            loadData = new LoadData();
            InitializeComponent();
        }
        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm newForm = new LoadForm();
            newForm.Show();
        }

        private void bookLoadButton_Click(object sender, EventArgs e)
        {
            loadData.LoadBookingHistoryData(ScheduleView);
            TableName = "BookingHistory";
        }

        private void schedLoadButton_Click(object sender, EventArgs e)
        {
            loadData.LoadTrainTicketsData(ScheduleView);
            TableName = "Tickets";
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            var newValue = ScheduleView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int id = int.Parse(ScheduleView.Rows[e.RowIndex].Cells["IDRoute"].Value.ToString());
            string ColumnName = ScheduleView.Columns[e.ColumnIndex].Name;
            var command = new SQLiteCommand($"UPDATE {TableName} SET {ColumnName} = @NewValue WHERE IDRoute = @ID", connection);
            command.Parameters.AddWithValue("@NewValue", newValue);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
            
        }
    }

}
