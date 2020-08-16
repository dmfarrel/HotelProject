using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    public class Employee
    {
        private int employeeId;

        private string name;
        private string username;
        private string password;
        private DateTime DOB;

        public Employee(int employeeId, string name, string username, string password, DateTime dateOfBirth)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.username = username;
            this.password = password;
            this.DOB = dateOfBirth;
        }

        public int getId()
        {
            return this.employeeId;
        }

        public string getName()
        {
            return this.name;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public DateTime getDateOfBirth()
        {
            return this.DOB;
        }
    }
}
