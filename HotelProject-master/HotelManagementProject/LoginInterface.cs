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

        private HotelManagementSystem hms;

        public LoginInterface()
        {
            InitializeComponent();

            this.hms = new HotelManagementSystem();
        }

        // Click the login button
        private void loginButton_Click(object sender, EventArgs e)
        {

            string username = this.loginUsernameTextBox.Text;   // Get the values in the text boxes
            string password = this.loginPasswordTextBox.Text;

            Dictionary<int, Employee> employees = this.hms.getEmployeeData();   // Get the data on all employees
            Dictionary<int, Customer> customers = this.hms.getCustomerData();   // Get the data on all customers

            // Loop through all employees
            foreach (var pair in employees)
            {
                if (pair.Value.getUsername().Equals(username))  // If the username matches, continue
                {
                    if (pair.Value.getPassword().Equals(password))  // If the password matches, show the employee interface
                    {
                        employeeInterface = new EmployeeInterface(pair.Value);  // Pass the employee information into the interface
                        employeeInterface.Show();
                        //this.Hide();
                        return;
                    }

                    ExceptionInterface excep = new ExceptionInterface("Password is invalid");   // Give Exception
                    excep.Show();
                    return;
                }
            }

            // Loop through all customers
            foreach (var pair in customers)
            {
                if (pair.Value.getUsername().Equals(username))  // If the username matches, continue
                {
                    if (pair.Value.getPassword().Equals(password)) // If the passowrd matches, show the customer interface
                    {
                        customerInterface = new CustomerInterface(pair.Value);  // Pass the customer information into the interface
                        customerInterface.Show();
                        //this.Hide();
                        return;
                    }

                    ExceptionInterface excep = new ExceptionInterface("Password is invalid");
                    excep.Show();
                    return;
                }
            }

            ExceptionInterface final_excep = new ExceptionInterface("Username is not found");
            return;

            //this.Hide();
        }

        private void LoginInterface_Load(object sender, EventArgs e)
        {

        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            string name = this.accountFirstTextBox.Text;
            string username = this.accountUsernameTextBox.Text;
            string password = this.accountPasswordTextBox.Text;
            string dobText = this.accountDOBTextBox.Text;

            DateTime dob;

            if (!DateTime.TryParseExact(dobText, "MM-dd-yy", null, System.Globalization.DateTimeStyles.None, out dob))
            {
                // If the parse fails, throw an exception and exit
                ExceptionInterface excep = new ExceptionInterface("Date of Birth must be in MM-dd-yy format");
                excep.Show();
                return;
            }

            Dictionary<int, Employee> employees = this.hms.getEmployeeData();   // Get the data on all employees
            Dictionary<int, Customer> customers = this.hms.getCustomerData();   // Get the data on all customers

            // Check if the username already exists in the customers
            foreach (var pair in customers)
            {
                if (pair.Value.getUsername().Equals(username))
                {
                    ExceptionInterface excep = new ExceptionInterface("This username already exists");
                    excep.Show();
                    return;
                }
            }

            // Check if the username already exists in the employees
            foreach (var pair in employees)
            {
                if (pair.Value.getUsername().Equals(username))
                {
                    ExceptionInterface excep = new ExceptionInterface("This username already exists");
                    excep.Show();
                    return;
                }
            }

            // Make the account depending on which radio button is checked
            if (customerRadioButton.Checked)
            {
                
                Customer customer = new Customer(0, name, username, password, dob, 0);
                this.hms.createNewCustomer(customer);

                ExceptionInterface excep = new ExceptionInterface("Successfully create account");
                excep.Show();

            } else if (employeeRadioButton.Checked)
            {

                Employee employee = new Employee(0, name, username, password, dob);
                this.hms.createNewEmployee(employee);

                ExceptionInterface excep = new ExceptionInterface("Successfully create account");
                excep.Show();

            } else
            {
                // Throw an exception if neither is checked
                ExceptionInterface excep = new ExceptionInterface("Please select either customer or employee");
                excep.Show();
            }
        }

        private void loginGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
