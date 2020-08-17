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
    public partial class CustomerInterface : Form
    {
        private Customer customer;
        private HotelManagementSystem hms;

        private Dictionary<int, Hotel> hotels;

        public CustomerInterface(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            this.hms = new HotelManagementSystem();
        }

        // Click create new transaction
        private void button4_Click(object sender, EventArgs e)
        {

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
            TransactionInterface transactionInterface = new TransactionInterface(this.customer, this.hms.getRoomData()[roomId], startDate, endDate);

            transactionInterface.Show();    // Show a transaction interface

            this.customer = hms.getCustomerData()[this.customer.getId()];
        }

        private void CustomerInterface_Load(object sender, EventArgs e)
        {
            Dictionary<int, Reservation> reservations = hms.getActiveReservationsOfCustomer(this.customer.getId());

            foreach (var pair in reservations)
            {
                reservationListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getRoomId()} - {pair.Value.getStartDate()} - {pair.Value.getEndDate()}");
            }

            hotels = hms.getHotelData();    // Get a list of all hotels

            foreach (var pair in hotels)    // Add each to the listbox for hotels
            {
                hotelListBox.Items.Add($"{pair.Value.getId()} - {pair.Value.getName()} - {pair.Value.getStreetAddress()}, {pair.Value.getCity()}, {pair.Value.getState()}");
            }

            this.rewardPointsLabel.Text = $"Reward Points: {this.customer.getRewardPoints()}";  // Set the label to current worth of reward points

            // Set the update information text boxes
            this.usernameTextBox.Text = this.customer.getUsername();
            this.firstTextBox.Text = this.customer.getName();
            this.passwordTextBox.Text = this.customer.getPassword();
        }

        // Cancel selected reservation
        private void button3_Click(object sender, EventArgs e)
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
            string item = roomListBox.SelectedItem.ToString();
            int roomId = Convert.ToInt32(item.Substring(0, item.IndexOf(' ')));

            Dictionary<int, Reservation> reservations = this.hms.getReservationsByRoom(roomId);

            roomReservationCalendar.RemoveAllBoldedDates();

            foreach (var pair in reservations)
            {
                DateTime startDate = pair.Value.getStartDate();
                DateTime endDate = pair.Value.getEndDate();

                for (DateTime i = startDate; i < endDate; i = i.AddDays(1)) roomReservationCalendar.AddBoldedDate(i);
            }

            roomReservationCalendar.UpdateBoldedDates();
        }

        // Update the user's information.
        private void updateInformationButton_Click(object sender, EventArgs e)
        {
            if (this.customer.getUsername().Equals(this.usernameTextBox.Text))
            {
                this.hms.updateCustomerInformation(this.customer.getId(), this.firstTextBox.Text, this.usernameTextBox.Text, this.passwordTextBox.Text);
                return;
            }

            Dictionary<int, Customer> customers = this.hms.getCustomerData();

            // Check to see if an inputted username already exists
            foreach (var pair in customers)
            {
                if (pair.Value.getUsername().Equals(this.usernameTextBox.Text))
                {
                    ExceptionInterface excep = new ExceptionInterface("This username already exists. Please select another");
                    excep.Show();
                    return;
                }
            }

            this.hms.updateCustomerInformation(this.customer.getId(), this.firstTextBox.Text, this.usernameTextBox.Text, this.passwordTextBox.Text);
        }

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }
    }
}
