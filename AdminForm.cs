using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        private LoadData loadData;
        private SQLiteConnection connection;
        private InitializeConnection initConn;

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
        }

        private void schedLoadButton_Click(object sender, EventArgs e)
        {
            loadData.LoadTrainTicketsData(ScheduleView);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateDataInDatabase();
        }

        private void UpdateDataInDatabase()
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            // Получаем измененные строки из DataGridView
            IEnumerable<DataGridViewRow> modifiedRows = ScheduleView.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null && cell.Value.ToString() != cell.OwningRow.Cells[cell.ColumnIndex].Value?.ToString()));

            if (modifiedRows.Any())
            {
                // Определяем имя таблицы, загруженной в DataGridView
                string tableName = ((DataTable)ScheduleView.DataSource).TableName;
                string primaryKeyColumn = ScheduleView.Columns[0].Name;

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    foreach (DataGridViewRow row in modifiedRows)
                    {
                        // Получаем значения измененных ячеек
                        var values = row.Cells.Cast<DataGridViewCell>()
                            .Where(cell => cell.Value != null && cell.Value.ToString() != cell.OwningRow.Cells[cell.ColumnIndex].Value?.ToString())
                            .ToDictionary(cell => cell.OwningColumn.Name, cell => cell.Value);

                        if (string.IsNullOrEmpty(row.Cells[primaryKeyColumn].Value?.ToString()))
                        {
                            // Формируем SQL-запрос для добавления новой записи
                            string insertQuery = $"INSERT INTO {tableName} ({string.Join(", ", values.Keys)}) VALUES ({string.Join(", ", values.Select(pair => $"@value_{pair.Key}"))})";

                            command.Parameters.Clear();

                            // Добавляем параметры в SQL-запрос
                            foreach (var pair in values)
                            {
                                command.Parameters.AddWithValue($"@value_{pair.Key}", pair.Value);
                            }

                            command.CommandText = insertQuery;
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            // Формируем SQL-запрос для обновления данных
                            string updateQuery = $"UPDATE {tableName} SET {string.Join(", ", values.Select(pair => $"{pair.Key} = @value_{pair.Key}"))} WHERE {primaryKeyColumn} = @primaryKeyValue";

                            command.Parameters.Clear();

                            // Добавляем параметры в SQL-запрос
                            foreach (var pair in values)
                            {
                                command.Parameters.AddWithValue($"@value_{pair.Key}", pair.Value);
                            }

                            command.Parameters.AddWithValue("@primaryKeyValue", row.Cells[primaryKeyColumn].Value);

                            command.CommandText = updateQuery;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


    }

}
