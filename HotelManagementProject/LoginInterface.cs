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
    public partial class LoginInterface : Form
    {
        private EmployeeInterface employeeInterface;
        private CustomerInterface customerInterface;

        public LoginInterface()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            employeeInterface = new EmployeeInterface();
            customerInterface = new CustomerInterface();

            employeeInterface.Show();
            customerInterface.Show();

            //this.Hide();
        }
    }
}
