using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoadForm : Form
    {
        private BookingManager bookingManager;
        private EmailManager emailManager;
        private LoadData loadData;
        private TicketsData ticketsData;

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
            ticketsData = new TicketsData();

            if (pointOfDep != "" && pointOfArr != "" && depDate != "  .  .")
            {
                var tickets = ticketsData.ReadTicketsFromDataGridView(ScheduleView);
                bookingManager.SearchTicketsByRouteAndDate(ScheduleView, tickets, pointOfDep, pointOfArr, depDate);
            }
            else if (pointOfDep != "" && pointOfArr != "" && depDate == "  .  .")
            {
                var tickets = ticketsData.ReadTicketsFromDataGridView(ScheduleView);
                bookingManager.SearchTicketsByRoute(ScheduleView, tickets, pointOfDep, pointOfArr);

            }
            else if (pointOfDep != "" && pointOfArr == "" && depDate == "  .  .")
            {
                var tickets = ticketsData.ReadTicketsFromDataGridView(ScheduleView);
                bookingManager.SearchTicketsByDeparture(ScheduleView, tickets, pointOfDep);

            }
            else if (pointOfDep != "" && pointOfArr == "" && depDate != "  .  .")
            {
                var tickets = ticketsData.ReadTicketsFromDataGridView(ScheduleView);
                bookingManager.SearchTicketsByDepartureAndDate(ScheduleView, tickets, pointOfDep, depDate);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ScheduleView.DataSource = null;
            ScheduleView.Rows.Clear();
            loadData.LoadTrainTicketsData(ScheduleView);
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.SelectedCells[0].RowIndex,
                idRoute = Convert.ToInt32(((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.Rows[selectedRowIndex].Cells["IDRoute"].Value),
                availableTickets = Convert.ToInt32(((LoadForm)Application.OpenForms["LoadForm"]).ScheduleView.Rows[selectedRowIndex].Cells["Seats"].Value);
            if (bookingManager.ReserveTickets(textBoxFullName.Text, textBoxPassport.Text, int.Parse(textBoxAmount.Text), textBoxEmail.Text, availableTickets, idRoute) && emailManager.SendConfirmationEmail(textBoxEmail.Text))
            {
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
