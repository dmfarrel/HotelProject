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
            employeeInterface = new EmployeeInterface(new Employee(1, "Esmeralda", "who even knows", "password", DateTime.Now));
            customerInterface = new CustomerInterface(new Customer(1, "Esmeralda", "who even knows", "password", DateTime.Now, 42));

            employeeInterface.Show();
            customerInterface.Show();

            //this.Hide();
        }

        private void LoginInterface_Load(object sender, EventArgs e)
        {

        }

        private void accountButton_Click(object sender, EventArgs e)
        {

        }
    }
}
