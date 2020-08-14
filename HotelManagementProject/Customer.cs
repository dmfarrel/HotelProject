using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    class Customer
    {
        private int customerId;

        private string name;
        private string username;
        private string password;
        private DateTime DOB;

        public Customer(int customerId, string name, string username, string password, DateTime dateOfBirth)
        {
            this.customerId = customerId;
            this.name = name;
            this.username = username;
            this.password = password;
            this.DOB = dateOfBirth;
        }

        public int getId()
        {
            return this.customerId;
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
