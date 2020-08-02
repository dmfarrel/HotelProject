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
        TransactionInterface transactionInterface;

        public EmployeeInterface()
        {
            InitializeComponent();
        }

        private void EmployeeInterface_Load(object sender, EventArgs e)
        {

        }

        private void newReservationButton_Click(object sender, EventArgs e)
        {
            transactionInterface = new TransactionInterface();

            transactionInterface.Show();
        }
    }
}
