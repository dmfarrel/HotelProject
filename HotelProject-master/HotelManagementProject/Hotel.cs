using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    public class Hotel
    {
        public int hotelId;
        public string streetAddress;
        public string city;
        public string state;
        public string name;

        public Hotel(int hotelId, string streetAddress, string city, string state, string name)
        {
            this.hotelId = hotelId;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.name = name;
        }

        public int getId()
        {
            return this.hotelId;
        }

        public string getStreetAddress()
        {
            return this.streetAddress;
        }

        public string getCity()
        {
            return this.city;
        }

        public string getState()
        {
            return this.state;
        }

        public string getName()
        {
            return this.name;
        }

    }
}
