using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProject
{
    public partial class EmployeeInterface : Form
    {
        private TransactionInterface transactionInterface;  // Transaction Interface for use when ending the reservation use case
        private HotelManagementSystem hms;                  // HMS class for use with all those other things

        private Dictionary<int, Customer> customers;
        private Dictionary<int, Hotel> hotels;

        public EmployeeInterface()
        {
            InitializeComponent();
        }

        private void EmployeeInterface_Load(object sender, EventArgs e)
        {
            hms = new HotelManagementSystem();          // Instantiate hms

            customers = hms.getCustomerData();

            foreach (var pair in customers)
            {
                customerListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getName()} - {pair.Value.getDateOfBirth()}");
            }

            hotels = hms.getHotelData();

            foreach (var pair in hotels)
            {
                hotelListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getName()} - {pair.Value.getStreetAddress()}, {pair.Value.getCity()}, {pair.Value.getState()}");
            }
        }

        private void newReservationButton_Click(object sender, EventArgs e)
        {
            transactionInterface = new TransactionInterface();

            transactionInterface.Show();    // Show a transaction interface
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            string startingDateString = this.reportBeginDateTextBox.Text;   // Get starting date string from UI
            string endingDateString = this.reportEndDateTextBox.Text;       // Get ending date string from UI

            DateTime startingDate, endingDate;  // DateTimes for comparison within the generator

            if (!DateTime.TryParseExact(startingDateString, "MM-dd-yy", null, System.Globalization.DateTimeStyles.None, out startingDate))
            {
                // If the parse fails, throw an exception and exit
                ExceptionInterface excep = new ExceptionInterface();   
                excep.setExceptionText("Starting Date must be in MM-dd-yy format");
                excep.Show();
                return;
            }

            if (!DateTime.TryParseExact(endingDateString, "MM-dd-yy", null, System.Globalization.DateTimeStyles.None, out endingDate))
            {
                // If the parse fails, throw an exception and exit
                ExceptionInterface excep = new ExceptionInterface();
                excep.setExceptionText("Ending Date must be in MM-dd-yy format");
                excep.Show();
                return;
            }

            this.summaryReportTextBox.Text = this.hms.generateSummaryReport(startingDate, endingDate).Replace("\n", Environment.NewLine);  // Use the hms to generate report and assign it to UI
        }

        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerId = customerListBox.SelectedIndex + 1;

            Dictionary<int, Reservation> activeReservations = this.hms.getActiveReservationsOfCustomer(customerId);

            reservationListBox.Items.Clear();

            foreach (var pair in activeReservations)
            {
                reservationListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getRoomId()} - {pair.Value.getStartDate()} - {pair.Value.getEndDate()}");
            }
        }

        private void hotelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hotelId = hotelListBox.SelectedIndex + 1;

            Dictionary<int, Room> rooms = this.hms.getRoomsByHotelId(hotelId);

            roomListBox.Items.Clear();

            foreach (var pair in rooms)
            {
                roomListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getType()} - {pair.Value.getPrice()}");
            }
        }

        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
