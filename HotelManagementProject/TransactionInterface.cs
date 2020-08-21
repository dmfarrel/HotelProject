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
    public partial class TransactionInterface : Form
    {
        private DateTime startDate;
        private DateTime endDate;
        private Customer customer;
        private Room room;

        private HotelManagementSystem hms;

        public TransactionInterface(Customer customer, Room room, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            this.customer = customer;
            this.room = room;

            this.startDate = startDate;
            this.endDate = endDate;

            this.hms = new HotelManagementSystem();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            int duration = (int)(this.endDate - this.startDate).TotalDays;

            // Calculate cost
            float cost = duration * this.room.getPrice() /* - amount earned from rewards*/;
            int rewardPointsEarned = duration * 25;
            int rewardPointsSpent = 0;
            
            // Still needs rewards points earned and rewards points spent
            Reservation reservation = new Reservation(0, customer.getId(), room.getId(), startDate, endDate, DateTime.Now, cost, rewardPointsEarned, rewardPointsSpent, false, false, 0);

            this.hms.insertReservation(reservation);
            this.hms.updateCustomerRewardPoints(customer.getId(), customer.getRewardPoints() - rewardPointsSpent + rewardPointsEarned);

            this.Close();
        }

        private void TransactionInterface_Load(object sender, EventArgs e)
        {
            int duration = (int)(this.endDate - this.startDate).TotalDays;
            float cost = duration * this.room.getPrice();

            this.costLabel.Text = $"Cost: {cost}";
        }
    }
}
