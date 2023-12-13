using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoadForm : Form
    {
        private BookingManager bookingManager;
        private EmailManager emailManager;
        private LoadData loadData;

        public LoadForm()
        {
            InitializeComponent();
            bookingManager = new BookingManager();
            emailManager = new EmailManager();
            loadData = new LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData.LoadTrainTicketsData(ScheduleView);

            ScheduleView.ReadOnly = true;
            ScheduleView.AllowUserToAddRows = false;
            ScheduleView.AllowUserToDeleteRows = false;
            ScheduleView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string pointOfDep = whereBox1.Text;
            string pointOfArr = whereBox2.Text;
            string depDate = maskedTextBox1.Text;

            if (pointOfDep != "" && pointOfArr != "" && depDate != "  .  .")
            {
                ScheduleView.DataSource = bookingManager.SearchTicketsByRouteAndDate(pointOfDep, pointOfArr, depDate);
            }
            else if (pointOfDep != "" && pointOfArr != "" && depDate == "  .  .")
            {
                ScheduleView.DataSource = bookingManager.SearchTicketsByRoute(pointOfDep, pointOfArr);
            }
            else if (pointOfDep != "" && pointOfArr == "" && depDate == "  .  .")
            {
                ScheduleView.DataSource = bookingManager.SearchTicketsByDeparture(pointOfDep);
            }
            else if (pointOfDep != "" && pointOfArr == "" && depDate != "  .  .")
            {
                ScheduleView.DataSource = bookingManager.SearchTicketsByDepartureAndDate(pointOfDep, depDate);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            loadData.LoadTrainTicketsData(ScheduleView);
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            if (bookingManager.ReserveTickets(textBoxFullName.Text, textBoxPassport.Text, int.Parse(textBoxAmount.Text), textBoxEmail.Text))
            {
                emailManager.SendConfirmationEmail(textBoxEmail.Text);
                MessageBox.Show("Билеты успешно забронированы и подтверждение отправлено на указанный адрес электронной почты!");
                loadData.LoadTrainTicketsData(ScheduleView);
            }
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            string temp = whereBox1.Text;
            whereBox1.Text = whereBox2.Text;
            whereBox2.Text = temp;
        }
        private void admButton_Click(object sender, EventArgs e)
        {
            AdmPanelAuth newForm = new AdmPanelAuth();
            newForm.Show();
            Hide();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
