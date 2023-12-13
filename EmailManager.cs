using System.Data.SQLite;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class EmailManager
    {
        private SQLiteConnection connection;
        private InitializeConnection initConn;

        public void SendConfirmationEmail(string recipientEmail)
        {
            initConn = new InitializeConnection(connection);
            connection = initConn.InitializeDatabaseConnection();
            string smtpHost = "smtp.yandex.ru";
            int smtpPort = 587;
            string smtpUsername = "train.system@yandex.ru";
            string smtpPassword = "ahrxohdxzemilzyj";
            string queryIdBook = "SELECT IDBooking FROM BookingHistory ORDER BY IDBooking DESC LIMIT 1;";
            using (SQLiteCommand command = new SQLiteCommand(queryIdBook, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int lastIDBook = reader.GetInt32(0);
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("train.system@yandex.ru");
                        message.To.Add(new MailAddress(recipientEmail));
                        message.Subject = "Бронирование билетов на поезд";
                        message.Body = $"Здравствуйте, вы успешно забронировали билет! Номер брони №{lastIDBook}";
                        SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(message);
                    }
                    else
                    {
                        MessageBox.Show("Строка не найдена");
                    }
                }
            }
        }
    }
}
