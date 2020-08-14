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
        TransactionInterface transactionInterface;

        public CustomerInterface()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            transactionInterface = new TransactionInterface();

            transactionInterface.Show();
        }

        private void CustomerInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
