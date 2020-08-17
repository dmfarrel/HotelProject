using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace HotelManagementProject
{
    public partial class EmployeeInterface : Form
    {
        //private TransactionInterface transactionInterface;  // Transaction Interface for use when ending the reservation use case
        private HotelManagementSystem hms;                  // HMS class for use with all those other things

        private Dictionary<int, Customer> customers;
        private Dictionary<int, Hotel> hotels;

        private Employee employee;

        public EmployeeInterface(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;
        }

        // On load
        private void EmployeeInterface_Load(object sender, EventArgs e)
        {
            hms = new HotelManagementSystem();          // Instantiate hms

            customers = hms.getCustomerData();  // Get a list of all customers

            foreach (var pair in customers) // Add each to the listbox for customers
            {
                customerListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getName()} - {pair.Value.getDateOfBirth()}");
            }

            hotels = hms.getHotelData();    // Get a list of all hotels

            foreach (var pair in hotels)    // Add each to the listbox for hotels
            {
                hotelListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getName()} - {pair.Value.getStreetAddress()}, {pair.Value.getCity()}, {pair.Value.getState()}");
            }
        }

        private void newReservationButton_Click(object sender, EventArgs e)
        {
            // If there hasn't been a customer selected, throw an exception and exit
            if (this.customerListBox.SelectedIndex == -1)
            {
                ExceptionInterface excep = new ExceptionInterface("Please select a customer and try again");
                excep.Show();
                return;
            }

            // If there hasn't been a room selected, throw an exception and exit
            if (this.roomListBox.SelectedIndex == -1)
            {
                ExceptionInterface excep = new ExceptionInterface("Please select a room and try again");
                excep.Show();
                return;
            }

            // If there hasn't been a date range selected, throw an exception and exit
            if (roomReservationCalendar.SelectionStart == null || roomReservationCalendar.SelectionEnd == null)
            {
                ExceptionInterface excep = new ExceptionInterface("Please select a date range and try again");
                excep.Show();
                return;
            }

            // Parse customer id from selected item
            string customerItem = customerListBox.SelectedItem.ToString();
            int customerId = Convert.ToInt32(customerItem.Substring(0, customerItem.IndexOf(' ')));

            // Parse room id from selected item
            string item = roomListBox.SelectedItem.ToString();
            int roomId = Convert.ToInt32(item.Substring(0, item.IndexOf(' ')));

            // Get start and end dates from calendar
            DateTime startDate = roomReservationCalendar.SelectionStart;
            DateTime endDate = roomReservationCalendar.SelectionEnd;

            Dictionary<int, Reservation> reservations = this.hms.getReservationsByRoom(roomId); // Fetch all existing reservations for the room

            // Check selected range against all reservations. If there's an overlap, throw an exception and exit
            foreach (var pair in reservations)
            {
                if (!(DateTime.Compare(endDate, pair.Value.getStartDate()) <= 0 || DateTime.Compare(startDate, pair.Value.getEndDate()) >= 0))
                {
                    // If the dates overlap, throw an exception and exit
                    ExceptionInterface excep = new ExceptionInterface("Selected reservation overlaps with another. Please try again");
                    excep.Show();
                    return;
                }
            }

            // Spawn the transaction interface and give it everything it needs to continue the use case
            TransactionInterface transactionInterface = new TransactionInterface(this.hms.getCustomerData()[customerId], this.hms.getRoomData()[roomId], startDate, endDate);

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
                ExceptionInterface excep = new ExceptionInterface("Starting date must be in MM-dd-yy format");   
                excep.Show();
                return;
            }

            if (!DateTime.TryParseExact(endingDateString, "MM-dd-yy", null, System.Globalization.DateTimeStyles.None, out endingDate))
            {
                // If the parse fails, throw an exception and exit
                ExceptionInterface excep = new ExceptionInterface("Ending date must be in MM-dd-yy format");
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
            int hotelId = hotelListBox.SelectedIndex + 1;   // Grad selected hotel

            Dictionary<int, Room> rooms = this.hms.getRoomsByHotelId(hotelId);  // Get all the rooms from that hotel

            roomListBox.Items.Clear();  // Clear the current list of items

            // Loop through each room and add it to the listbox
            foreach (var pair in rooms)
            {
                roomListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getType()} - {pair.Value.getPrice()}");
            }
        }

        // Select a new room, update the calendar with active reservations
        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Parse room id from list item
            string item = roomListBox.SelectedItem.ToString();
            int roomId = Convert.ToInt32(item.Substring(0, item.IndexOf(' ')));

            Dictionary<int, Reservation> reservations = this.hms.getReservationsByRoom(roomId); // Get all reservations

            roomReservationCalendar.RemoveAllBoldedDates(); // Clear current bolded dates

            // Loop through each reservation and bold the active dates
            foreach (var pair in reservations)
            {
                DateTime startDate = pair.Value.getStartDate();
                DateTime endDate = pair.Value.getEndDate();

                for (DateTime i = startDate; i < endDate; i = i.AddDays(1)) roomReservationCalendar.AddBoldedDate(i);
            }

            roomReservationCalendar.UpdateBoldedDates();    // Repaint the calendar
        }

        // Click button for cancel reservation
        private void cancelReservationButton_Click(object sender, EventArgs e)
        {
            // If a reservation hasn't been selected, throw an exception and exit
            if (this.reservationListBox.SelectedIndex == -1)
            {
                ExceptionInterface excep = new ExceptionInterface("Please select a reservation and try again");
                excep.Show();
                return;
            }

            // Parse the reservation id from the list item
            string item = reservationListBox.SelectedItem.ToString();
            int reservationId = Convert.ToInt32(item.Substring(0, item.IndexOf(' ')));

            // Set to cancelled in the database and remove it from the list
            this.hms.cancelReservation(reservationId);
            this.reservationListBox.Items.RemoveAt(this.reservationListBox.SelectedIndex);
        }

        // Parses the weird file format for the input files
        private DateTime parseFileDateString(string date)
        {
            string year = date.Substring(0, 4).Substring(2, 2);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            return DateTime.ParseExact($"{month}-{day}-{year}", "MM-dd-yy", null);
        }

        // Method to load the external file for reservations
        private void loadReservationFileButton_Click(object sender, EventArgs e)
        {
            string path = loadReservationFileTextBox.Text;

            // Check if file exists in the first place
            if (!File.Exists(path))
            {
                ExceptionInterface excep = new ExceptionInterface("This file does not exist");
                excep.Show();
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(path); // Read file into an array of lines

            if (lines.Length == 0)  // If the file is empty, throw an exception
            {
                ExceptionInterface excep = new ExceptionInterface("This file is empty");
                excep.Show();
                return;
            }

            DateTime creationDate = parseFileDateString(lines[0]);  // Parse out the creation date

            // Loop through each entry in the file
            for (int i = 1; i < lines.Length; i++)
            {
                String[] tokens = lines[i].Split(' ');

                int reservationId = Convert.ToInt32(tokens[1]);
                int customerId = Convert.ToInt32(tokens[3]);
                int hotelId = Convert.ToInt32(tokens[5]);
                int roomId = Convert.ToInt32(tokens[7]);

                DateTime startDate = parseFileDateString(tokens[9]);
                DateTime endDate = parseFileDateString(tokens[11]);

                Dictionary<int, Reservation> reservations = this.hms.getReservationsByRoom(roomId);

                foreach (var pair in reservations)
                {
                    if (!(DateTime.Compare(endDate, pair.Value.getStartDate()) <= 0 || DateTime.Compare(startDate, pair.Value.getEndDate()) >= 0))
                    {
                        // If the dates overlap, throw an exception and exit
                        ExceptionInterface excep = new ExceptionInterface("One inputted reservation overlaps with existing");
                        excep.Show();
                        return;
                    }
                }

                Customer customer = this.hms.getCustomerData()[customerId];
                Room room = this.hms.getRoomData()[roomId];

                int duration = (int)(endDate - startDate).TotalDays;

                // Calculate cost
                float cost = duration * room.getPrice() /* - amount earned from rewards*/;
                int rewardPointsEarned = duration * 25;
                int rewardPointsSpent = 0;

                Reservation reservation = new Reservation(0, customer.getId(), room.getId(), startDate, endDate, creationDate, cost, rewardPointsEarned, rewardPointsSpent, false, false, 0);

                this.hms.insertReservation(reservation);
                this.hms.updateCustomerRewardPoints(customer.getId(), customer.getRewardPoints() - rewardPointsSpent + rewardPointsEarned);
            }
        }
    }
}
