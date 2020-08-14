using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    class Room
    {
        private string roomType;
        private float roomPrice;
        private string amenities;
        private bool reserved;

        private int roomId;
        private int hotelId;

        public Room(int roomId, int hotelId, string roomType, float roomPrice, string amenities, bool reserved)
        {
            this.roomId = roomId;
            this.hotelId = hotelId;

            this.roomType = roomType;
            this.roomPrice = roomPrice;
            this.amenities = amenities;
            this.reserved = reserved;
        }

        public float getPrice()
        {
            return this.roomPrice;
        }

        public int getId()
        {
            return this.roomId;
        }

        public int getHotelId()
        {
            return this.hotelId;
        }

        public string getType()
        {
            return this.roomType;
        }

        public string getAmenities()
        {
            return this.amenities;
        }

        public bool isReserved()
        {
            return this.reserved;
        }
    }
}
