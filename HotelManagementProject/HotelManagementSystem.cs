using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace HotelManagementProject
{
    class HotelManagementSystem
    {
        private SqlConnection conn;
        private string connectionString = "";

        public HotelManagementSystem()
        {
            this.conn = new SqlConnection(this.connectionString);
        }

        // Method to get all reservations that exist within a date range
        private Dictionary<int, Object[]> getReservationDataWithinRange(DateTime startingDate, DateTime endingDate, bool creationDate = false)
        {
            Dictionary<int, Object[]> dataList = new Dictionary<int, Object[]>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand("SELECT * FROM Reservation", this.conn);    // Sql command to get all reservations

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int reservationId = (int)rdr[0];
                    int customerId = (int)rdr[1];
                    int transactionId = (int)rdr[2];
                    int roomId = (int)rdr[3];

                    string hotelName = (string)rdr[4];
                    DateTime reservationStartDate = DateTime.ParseExact((string)rdr[5], "MM-dd-yy", null);
                    DateTime reservationEndDate = DateTime.ParseExact((string)rdr[6], "MM-dd-yy", null);
                    bool cancelled = (bool)rdr[7];
                    bool upgraded = (bool)rdr[8];
                    DateTime dateOfReservation = DateTime.ParseExact((string)rdr[9], "MM-dd-yy", null);

                    // If creationDate is true, the range is based on when the reservation is created
                    // Otherwise, it's based on when the reservation exists
                    if (creationDate)
                    {
                        // If the reservation exists within the range, add it to the list
                        if (DateTime.Compare(startingDate, dateOfReservation) >= 0 && DateTime.Compare(dateOfReservation, endingDate) <= 0)
                        {
                            Object[] data = { reservationId, customerId, transactionId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, cancelled, upgraded };

                            dataList.Add(reservationId, data);
                        }
                    }
                    else
                    {
                        // If the reservation exists within the range, add it to the list
                        if (DateTime.Compare(startingDate, reservationStartDate) >= 0 && DateTime.Compare(reservationEndDate, endingDate) <= 0)
                        {
                            Object[] data = { reservationId, customerId, transactionId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, cancelled, upgraded };

                            dataList.Add(reservationId, data);
                        }
                    }
                }

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();    // Close the data reader
                }

                if (this.conn != null)
                {
                    this.conn.Close();  // Close the connection
                }
            }

            return dataList;    // Return the list of data
        }

        // Returns a dictionary containing the data for every hotel in the database
        public Dictionary<int, Object[]> getHotelData()
        {
            Dictionary<int, Object[]> dataList = new Dictionary<int, Object[]>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand("SELECT * FROM Hotel", this.conn);    // Sql command to get all hotels

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int hotelId = (int)rdr[0];
                    string streetAddress = (string)rdr[1];
                    string city = (string)rdr[2];
                    string state = (string)rdr[3];
                    string name = (string)rdr[4];

                    Object[] data = { hotelId, streetAddress, city, state, name };

                    dataList.Add(hotelId, data);
                }

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();    // Close the data reader
                }

                if (this.conn != null)
                {
                    this.conn.Close();  // Close the connection
                }
            }

            return dataList;    // Return the list of data
        }

        // Gets all rooms that have a specific hotelId
        public Dictionary<int, Object[]> getRoomsByHotelId(int hotelId)
        {
            Dictionary<int, Object[]> dataList = new Dictionary<int, Object[]>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand($"SELECT * FROM Room WHERE hotelID={hotelId}", this.conn);    // Sql command to get all hotels

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int roomId = (int)rdr[0];
                    string roomType = (string)rdr[1];
                    string roomPrice = (string)rdr[2];
                    string amenities = (string)rdr[3];
                    bool reserved = (bool)rdr[4];

                    Object[] data = { roomId, roomType, roomPrice, amenities, reserved };

                    dataList.Add(roomId, data);
                }

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();    // Close the data reader
                }

                if (this.conn != null)
                {
                    this.conn.Close();  // Close the connection
                }
            }

            return dataList;    // Return the list of data
        }

        public int countReservedRooms(Dictionary<int, Object[]> rooms)
        {
            int count = 0;

            foreach (var pair in rooms)
            {
                int roomId = pair.Key;
                Object[] data = pair.Value;

                if ((bool)data[3] == true) count++;
            }

            return count;
        }

        public int getOutstandingRewardsPoints()
        {
            int count = 0;

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getNumberOfCustomers = new SqlCommand("SELECT sum(RewardsPoints) FROM Customer", this.conn);    // Sql command to sum of rewards points

                count = (int)getNumberOfCustomers.ExecuteScalar(); // Execute command
            }
            finally
            {
                if (this.conn != null)
                {
                    this.conn.Close();  // Close the connection
                }
            }

            return count;    // Return the list of data
        }

        public int sumRewardsPointsAcrossReservations(Dictionary<int, Object[]> reservations, bool net = true)
        {
            int sum = 0;    // Sum integer for accumulation pattern

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Object[] reservationData = pair.Value;

                if (net) sum += (int)reservationData[0] - (int)reservationData[1];  // If net, add the points earned minus the points spent
                    else sum += (int)reservationData[0];    // If not net, only add the points earned
            }

            return sum;
        }

        public int sumRevenueAcrossReservations(Dictionary<int, Object[]> reservations)
        {
            int sum = 0;

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Object[] reservationData = pair.Value;

                sum += (int)reservationData[2];
            }

            return sum;
        }

        public int getCountOfTable(string tableName)
        {
            int count = 0;

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getNumberOfCustomers = new SqlCommand($"SELECT count(*) FROM {tableName}", this.conn);    // Sql command to get all hotels

                count = (int)getNumberOfCustomers.ExecuteScalar(); // Execute command
            }
            finally
            {
                if (this.conn != null)
                {
                    this.conn.Close();  // Close the connection
                }
            }

            return count;    // Return the list of data
        }

        public string generateSummaryReport(DateTime startingDate, DateTime endingDate)
        {

            string startingDateString = startingDate.ToString("MM-dd-yy");
            string endingDateString = endingDate.ToString("MM-dd-yy");
            string summaryReport = $"Summary Report from {startingDateString} to {endingDateString}\n\n";

            
            Dictionary<int, Object[]> reservationCreatedData = this.getReservationDataWithinRange(startingDate, endingDate, false);     // Reservations based on when they were created
            Dictionary<int, Object[]> reservationsNowToEndDate = this.getReservationDataWithinRange(endingDate, DateTime.Now, true);    // Reservations that happened between enddate and now
            Dictionary<int, Object[]> reservationExistsData = this.getReservationDataWithinRange(startingDate, endingDate, true);       // Reservations that happened in range

            // Get Rewards Points stats
            int currentPoints = this.getOutstandingRewardsPoints();     // Get total points at current time
            int netPointsAfterEndDate = this.sumRewardsPointsAcrossReservations(reservationsNowToEndDate);  // Get net points between end date and now
            int netPointsDuringPeriod = this.sumRewardsPointsAcrossReservations(reservationExistsData);     // Get net points between start and end date
            int pointsEarnedDuringPeriod = this.sumRewardsPointsAcrossReservations(reservationExistsData, false);   // Get positive points earned between start and end date

            // Add rewards points information to the report
            summaryReport +=    "Reward Points Summary\n" +
                                $"Rewards outstanding on date {startingDateString} - {currentPoints + netPointsAfterEndDate + netPointsDuringPeriod}\n" +
                                $"Rewards redeemed between {startingDateString} and {endingDateString} - {netPointsDuringPeriod - pointsEarnedDuringPeriod}\n" +
                                $"Rewards earned between {startingDateString} and {endingDateString} - {pointsEarnedDuringPeriod}\n" +
                                $"Rewards outstanding on date {endingDateString} - {currentPoints + netPointsAfterEndDate}\n\n";


            // Compute per hotel occupancy stats
            Dictionary<int, Object[]> hotels = this.getHotelData();

            int totalRooms = 0;
            int totalReserved = 0;
            int totalRevenue = this.sumRevenueAcrossReservations(reservationExistsData);

            summaryReport += $"Occupancies and Revenue between {startingDateString} and {endingDateString}\n";

            // Loop through each hotel for occupancy stats
            foreach(var pair in hotels)
            {
                int key = pair.Key;
                Object[] data = pair.Value;

                Dictionary<int, Object[]> rooms = this.getRoomsByHotelId(key);

                int roomsInHotel = rooms.Count;
                int reservedRoomsInHotel = this.countReservedRooms(rooms);
                int freeRoomsInHotel = roomsInHotel - reservedRoomsInHotel;

                totalRooms += roomsInHotel;
                totalReserved += reservedRoomsInHotel;

                float occupancyRate = (float)reservedRoomsInHotel / roomsInHotel;

                summaryReport += $"Hotel {data[4]} Occupancy Rate - {occupancyRate}\n";
            }

            summaryReport += $"Chain Occupancy Rate - {(float)totalReserved / totalRooms} - ${totalRevenue}\n\n";


            // Compute other statistics

            return summaryReport;
        }
    }
}
