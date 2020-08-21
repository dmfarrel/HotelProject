using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace HotelManagementProject
{
    public class HotelManagementSystem
    {
        private SqlConnection conn;
        private string connectionString = "Data Source=hotelmanagement375.database.windows.net;Initial Catalog=HotelManagement;User ID=hoteladmin;Password=Letmein123";

        public HotelManagementSystem()
        {
            this.conn = new SqlConnection(this.connectionString);
        }

        // Inserts a reservation into the database
        public bool insertReservation(Reservation reservation)
        {
            try
            {
                conn.Open();

                int roomId = reservation.getRoomId();
                int customerId = reservation.getCustomerId();
                string startDate = reservation.getStartDate().ToString("MM-dd-yy");
                string endDate = reservation.getEndDate().ToString("MM-dd-yy");
                float cost = reservation.getCost();
                int rewardPointsEarned = reservation.getRewardPointsEarned();
                int rewardPointsSpent = reservation.getRewardPointsSpent();
                string dateOfReservation = reservation.getMadeDate().ToString("MM-dd-yy");

                string insertString = $"INSERT INTO Reservation (RoomId,CustomerId,StartDate,EndDate,Cost,Waitlist,Cancelled,Upgraded,RewardPointsEarned,RewardPointsSpent,DateOfReservation) " +
                                      $"VALUES ({roomId},{customerId},'{startDate}','{endDate}',{cost},0,0,0,{rewardPointsEarned},{rewardPointsSpent},'{dateOfReservation}')";

                SqlCommand cmd = new SqlCommand(insertString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        // Method to set the boolean value in the database for reservation to true
        private bool setReservationCancel(int reservationId)
        {
            try
            {
                conn.Open();

                string updateString = $"UPDATE Reservation SET Cancelled=1 WHERE ReservationId={reservationId}";

                SqlCommand cmd = new SqlCommand(updateString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public bool updateCustomerInformation(int customerId, string newName, string newUsername, string newPassword)
        {
            try
            {
                conn.Open();

                string updateString = $"UPDATE Customer SET Name='{newName}', USername='{newUsername}', Password='{newPassword}' WHERE CustomerId={customerId}";

                SqlCommand cmd = new SqlCommand(updateString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public bool updateCustomerRewardPoints(int customerId, int rewardPoints)
        {
            try
            {
                conn.Open();

                string updateString = $"UPDATE Customer SET RewardPoints={rewardPoints} WHERE CustomerId={customerId}";

                SqlCommand cmd = new SqlCommand(updateString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        // Insert new customer into table
        public bool createNewCustomer(Customer customer)
        {
            try
            {
                conn.Open();

                string name = customer.getName();
                string username = customer.getUsername();
                string password = customer.getPassword();
                string dateOfBirth = customer.getDateOfBirth().ToString("MM-dd-yy");
                
                string insertString = $"INSERT INTO Customer (Name,Username,Password,DateOfBirth,RewardPoints) " +
                                      $"VALUES ('{name}','{username}','{password}','{dateOfBirth}',0)";

                SqlCommand cmd = new SqlCommand(insertString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        // Insert new employee into table
        public bool createNewEmployee(Employee employee)
        {
            try
            {
                conn.Open();

                string name = employee.getName();
                string username = employee.getUsername();
                string password = employee.getPassword();
                string dateOfBirth = employee.getDateOfBirth().ToString("MM-dd-yy");

                string insertString = $"INSERT INTO Employee (Name,Username,Password,DateOfBirth,Wage) " +
                                      $"VALUES ('{name}','{username}','{password}','{dateOfBirth}',7.25)";

                SqlCommand cmd = new SqlCommand(insertString, conn);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public int createNewReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            // Get all other noncancelled reservations for this room
            // Check if this timespan overlaps with any other non-cancelled reservations, while getting max of their waitlists
            // Create reservation object
            // Add to database

            return 0;
        }

        public bool cancelReservation(int reservationId)
        {
            // Get room id for reservation
            // Set value of row to cancelled, decrement waitlist of all other 
            setReservationCancel(reservationId);
            return true;
        }

        public bool AddHotel(Hotel hotel)
        {
            Dictionary<int, Hotel> datalist = new Dictionary<int, Hotel>();
            this.conn.Open();
            try
            {
                SqlCommand addHotel = new SqlCommand("Select *FROM Hotel", this.conn);

                int hotelId = 0;
                string name = hotel.getName();
                string address = hotel.getStreetAddress();
                string city = hotel.getCity();
                string state = hotel.getState();

                string insertString = $"INSERT INTO Hotel (Name,streetAddress,City,State) " +
                                      $"VALUES ( '{name}','{address}','{city}','{state}') ";

                SqlCommand cmd = new SqlCommand(insertString, conn);
                cmd.ExecuteNonQuery();
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public bool AddRoom(Room room)
        {
            Dictionary<int, Hotel> datalist = new Dictionary<int, Hotel>();
            this.conn.Open();
            try
            {
                SqlCommand addHotel = new SqlCommand("Select *FROM Room", this.conn);

                int roomId = room.getId();
                string type = room.getType();
                float cost = room.getPrice();
                int hotelId = room.getHotelId();

                string insertString = $"INSERT INTO Room (HotelId,RoomType,Price, Amenities, Reserved) " +
                                      $"VALUES ( {hotelId},'{type}',{cost}, '', 0)";

                SqlCommand cmd = new SqlCommand(insertString, conn);
                cmd.ExecuteNonQuery();
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public bool DeleteRoom(Room room)
        {
            Dictionary<int, Hotel> datalist = new Dictionary<int, Hotel>();
            this.conn.Open();
            try
            {
                SqlCommand deleteRoom = new SqlCommand("Select *FROM Room", this.conn);

                int roomId = room.getId();
                string type = room.getType();
                float cost = room.getPrice();
                int hotelId = room.getHotelId();

                string insertString = $"Delete From Room Where RoomId = {roomId}";

                SqlCommand cmd = new SqlCommand(insertString, conn);
                cmd.ExecuteNonQuery();
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        public bool DeleteHotel(Hotel hotel)
        {
            this.conn.Open();
            try
            {
                SqlCommand deleteHotel = new SqlCommand("Select *FROM Hotel", this.conn);

                int hotelId = hotel.getId();
                string name = hotel.getName();
                string address = hotel.getStreetAddress();
                string city = hotel.getCity();
                string state = hotel.getState();

                string insertString = $"Delete From Hotel Where HotelId = {hotelId}";

                SqlCommand cmd = new SqlCommand(insertString, conn);
                cmd.ExecuteNonQuery();
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }

        // Method to get all reservations that exist within a date range
        public Dictionary<int, Reservation> getReservationDataWithinRange(DateTime startingDate, DateTime endingDate, bool creationDate = false)
        {
            Dictionary<int, Reservation> dataList = new Dictionary<int, Reservation>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand("SELECT * FROM Reservation", this.conn);    // Sql command to get all reservations

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int reservationId = (int)rdr[0];
                    int customerId = (int)rdr[2];
                    int roomId = (int)rdr[1];
                    
                    DateTime reservationStartDate = DateTime.ParseExact((string)rdr[3], "MM-dd-yy", null);
                    DateTime reservationEndDate = DateTime.ParseExact((string)rdr[4], "MM-dd-yy", null);
                    bool cancelled = (int)rdr[7] != 0;
                    bool upgraded = (int)rdr[8] != 0;
                    double cost = (double)rdr[5];
                    int rewardsPointsEarned = (int)rdr[9];
                    int rewardsPointsSpent = (int)rdr[10];
                    DateTime dateOfReservation = DateTime.ParseExact((string)rdr[11], "MM-dd-yy", null);
                    int waitlist = (int)rdr[6];

                    // If creationDate is true, the range is based on when the reservation is created
                    // Otherwise, it's based on when the reservation exists
                    if (creationDate)
                    {
                        // If the reservation exists within the range, add it to the list
                        if (DateTime.Compare(startingDate, dateOfReservation) <= 0 && DateTime.Compare(dateOfReservation, endingDate) <= 0)
                        {
                            Reservation reservation = new Reservation(reservationId, customerId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, (float)cost, rewardsPointsEarned, rewardsPointsSpent, cancelled, upgraded, waitlist);
                            dataList.Add(reservationId, reservation);
                        }
                    }
                    else
                    {
                        // If the reservation exists within the range, add it to the list
                        if (DateTime.Compare(startingDate, reservationStartDate) <= 0 && DateTime.Compare(reservationEndDate, endingDate) <= 0)
                        {
                            Reservation reservation = new Reservation(reservationId, customerId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, (float)cost, rewardsPointsEarned, rewardsPointsSpent, cancelled, upgraded, waitlist);
                            dataList.Add(reservationId, reservation);
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

        public Dictionary<int, Reservation> getActiveReservationsOfCustomer(int customerId)
        {
            Dictionary<int, Reservation> dataList = new Dictionary<int, Reservation>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand($"SELECT * FROM Reservation WHERE CustomerId={customerId}", this.conn);    // Sql command to get all reservations

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int reservationId = (int)rdr[0];
                    int roomId = (int)rdr[1];

                    DateTime reservationStartDate = DateTime.ParseExact((string)rdr[3], "MM-dd-yy", null);
                    DateTime reservationEndDate = DateTime.ParseExact((string)rdr[4], "MM-dd-yy", null);
                    bool cancelled = (int)rdr[7] != 0;
                    bool upgraded = (int)rdr[8] != 0;
                    double cost = (double)rdr[5];
                    int rewardsPointsEarned = (int)rdr[9];
                    int rewardsPointsSpent = (int)rdr[10];
                    DateTime dateOfReservation = DateTime.ParseExact((string)rdr[11], "MM-dd-yy", null);
                    int waitlist = (int)rdr[6];

                    if (DateTime.Compare(reservationStartDate, DateTime.Now) > 0 && !cancelled && !upgraded)
                    {
                        Reservation reservation = new Reservation(reservationId, customerId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, (float)cost, rewardsPointsEarned, rewardsPointsSpent, cancelled, upgraded, waitlist);
                        dataList.Add(reservationId, reservation);
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

        public Dictionary<int, Reservation> getReservationsByRoom(int roomId)
        {
            Dictionary<int, Reservation> dataList = new Dictionary<int, Reservation>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand($"SELECT * FROM Reservation WHERE RoomId={roomId}", this.conn);    // Sql command to get all reservations

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int reservationId = (int)rdr[0];
                    int customerId = (int)rdr[2];
                    DateTime reservationStartDate = DateTime.ParseExact((string)rdr[3], "MM-dd-yy", null);
                    DateTime reservationEndDate = DateTime.ParseExact((string)rdr[4], "MM-dd-yy", null);
                    bool cancelled = (int)rdr[7] != 0;
                    bool upgraded = (int)rdr[8] != 0;
                    double cost = (double)rdr[5];
                    int rewardsPointsEarned = (int)rdr[9];
                    int rewardsPointsSpent = (int)rdr[10];
                    DateTime dateOfReservation = DateTime.ParseExact((string)rdr[11], "MM-dd-yy", null);
                    int waitlist = (int)rdr[6];

                    if (!cancelled)
                    {
                        Reservation reservation = new Reservation(reservationId, customerId, roomId, reservationStartDate, reservationEndDate, dateOfReservation, (float)cost, rewardsPointsEarned, rewardsPointsSpent, cancelled, upgraded, waitlist);
                        dataList.Add(reservationId, reservation);
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
        public Dictionary<int, Hotel> getHotelData()
        {
            Dictionary<int, Hotel> dataList = new Dictionary<int, Hotel>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand("SELECT * FROM Hotel", this.conn);    // Sql command to get all hotels

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int hotelId = (int)rdr[0];
                    string name = (string)rdr[1];
                    string streetAddress = (string)rdr[2];
                    string city = (string)rdr[3];
                    string state = (string)rdr[4];

                    Hotel hotel = new Hotel(hotelId, streetAddress, city, state, name); // Create hotel data object

                    dataList.Add(hotelId, hotel);   // Add hotel object to the dictionary
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

        public Dictionary<int, Customer> getCustomerData()
        {
            Dictionary<int, Customer> dataList = new Dictionary<int, Customer>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getCustomers = new SqlCommand("SELECT * FROM Customer", this.conn);    // Sql command to get all hotels

                rdr = getCustomers.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int customerId = (int)rdr[0];
                    string name = (string)rdr[1];
                    string username = (string)rdr[2];
                    string password = (string)rdr[3];
                    DateTime dateOfBirth = DateTime.ParseExact((string)rdr[4], "MM-dd-yy", null);
                    int rewardPoints = (int)rdr[5];

                    Customer customer = new Customer(customerId, name, username, password, dateOfBirth, rewardPoints); // Create hotel data object

                    dataList.Add(customerId, customer);   // Add hotel object to the dictionary
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

        // Gets information on all employees
        public Dictionary<int, Employee> getEmployeeData()
        {
            Dictionary<int, Employee> dataList = new Dictionary<int, Employee>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getCustomers = new SqlCommand("SELECT * FROM Employee", this.conn);    // Sql command to get all hotels

                rdr = getCustomers.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int employeeId = (int)rdr[0];
                    string name = (string)rdr[1];
                    string username = (string)rdr[2];
                    string password = (string)rdr[3];
                    DateTime dateOfBirth = DateTime.ParseExact((string)rdr[4], "MM-dd-yy", null);

                    Employee employee = new Employee(employeeId, name, username, password, dateOfBirth); // Create hotel data object

                    dataList.Add(employeeId, employee);   // Add hotel object to the dictionary
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

        // Gets information on all rooms
        public Dictionary<int, Room> getRoomData()
        {
            Dictionary<int, Room> dataList = new Dictionary<int, Room>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand($"SELECT * FROM Room", this.conn);    // Sql command to get all hotels

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int roomId = (int)rdr[0];
                    int hotelId = (int)rdr[1];
                    string roomType = (string)rdr[3];
                    double roomPrice = (double)rdr[2];
                    string amenities = (string)rdr[4];
                    bool reserved = (int)rdr[5] != 0;

                    Room room = new Room(roomId, hotelId, roomType, (float)roomPrice, amenities, reserved);

                    dataList.Add(roomId, room);
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
        public Dictionary<int, Room> getRoomsByHotelId(int hotelId)
        {
            Dictionary<int, Room> dataList = new Dictionary<int, Room>();     // Empty list to hold data to return

            SqlDataReader rdr = null;   // For reading data

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getReservations = new SqlCommand($"SELECT * FROM Room WHERE hotelId={hotelId}", this.conn);    // Sql command to get all hotels

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int roomId = (int)rdr[0];
                    string roomType = (string)rdr[3];
                    double roomPrice = (double)rdr[2];
                    string amenities = (string)rdr[4];
                    bool reserved = (int)rdr[5] != 0;
                    
                    Room room = new Room(roomId, hotelId, roomType, (float)roomPrice, amenities, reserved);

                    dataList.Add(roomId, room);
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

        // Count how many rooms are reserved in a set
        public int countReservedRooms(Dictionary<int, Room> rooms)
        {
            int count = 0;

            foreach (var pair in rooms)
            {
                int roomId = pair.Key;
                Room data = pair.Value;

                if (data.isReserved() == true) count++;
            }

            return count;
        }
        
        // Count how many total rooms are reserved for any amount of time in a set of reservations
        public int countReservedRooms(Dictionary<int, Reservation> reservations)
        {
            int count = 0;

            HashSet<int> rooms = new HashSet<int>();

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation data = pair.Value;

                if (!rooms.Contains(data.getRoomId()))
                {
                    rooms.Add(data.getRoomId());
                    count++;
                }
            }

            return count;
        }

        // Count how many reservations have been cancelled in a set
        public int countCancelledReservations(Dictionary<int, Reservation> reservations)
        {
            int count = 0;

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reserv = pair.Value;

                if (reserv.isCancelled()) count++;
            }

            return count;
        }

        // Count how many reservations have been upgraded in a set
        public int countUpgradedReservations(Dictionary<int, Reservation> reservations)
        {
            int count = 0;

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reserv = pair.Value;

                if (reserv.isUpgraded()) count++;
            }

            return count;
        }

        // Count how many reservations are still active in a set
        public int countActiveReservations(Dictionary<int, Reservation> reservations)
        {
            int count = 0; 

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reserv = pair.Value;

                if (!reserv.isCancelled() && !reserv.isUpgraded()) count++;
            }

            return count;
        }

        // Count how many repeat customers in a set of reservations
        public int countRepeatCustomers(Dictionary<int, Reservation> reservations)
        {
            HashSet<int> customers = new HashSet<int>();

            int count = 0;

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reserv = pair.Value;

                // If the customer isn't in the set, add to set. Otherwise increment count since repeat
                if (!customers.Contains(reserv.getCustomerId())) customers.Add(reserv.getCustomerId());
                    else count++;
            }

            return count;
        } 

        // Get how many rewards points are currently held by customers
        public int getOutstandingRewardsPoints()
        {
            int count = 0;

            try
            {
                this.conn.Open();   // Open the SQL connection

                SqlCommand getNumberOfCustomers = new SqlCommand("SELECT sum(RewardPoints) FROM Customer", this.conn);    // Sql command to sum of rewards points

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

        // Calculate all reward points in a set of reservations
        public int sumRewardsPointsAcrossReservations(Dictionary<int, Reservation> reservations, bool net = true)
        {
            int sum = 0;    // Sum integer for accumulation pattern

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reservationData = pair.Value;

                if (net) sum += reservationData.getRewardPointsEarned() - reservationData.getRewardPointsSpent();  // If net, add the points earned minus the points spent
                    else sum += reservationData.getRewardPointsEarned();    // If not net, only add the points earned
            }

            return sum;
        }

        // Given a set of reservations, calculate the revenue across all of them
        public float sumRevenueAcrossReservations(Dictionary<int, Reservation> reservations)
        {
            float sum = 0;

            foreach (var pair in reservations)
            {
                int reservationId = pair.Key;
                Reservation reservationData = pair.Value;

                if (!reservationData.isCancelled() && !reservationData.isUpgraded() && reservationData.getWaitlist() == 0) sum += reservationData.getCost();
            }

            return sum;
        }

        // Method that counts the number of entries in any table in the database
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

        public bool createNewHotel(Hotel hotel)
        {

            return true;
        }

        public string generateSummaryReport(DateTime startingDate, DateTime endingDate)
        {

            string startingDateString = startingDate.ToString("MM-dd-yy");      // Get the date strings for interpolating later
            string endingDateString = endingDate.ToString("MM-dd-yy");
            string summaryReport = $"Summary Report from {startingDateString} to {endingDateString}\n\n";   // Kick off summary report
            
            Dictionary<int, Reservation> reservationCreatedData = this.getReservationDataWithinRange(startingDate, endingDate, false);     // Reservations based on when they were created
            Dictionary<int, Reservation> reservationsNowToEndDate = this.getReservationDataWithinRange(endingDate, DateTime.Now, true);    // Reservations that happened between enddate and now
            Dictionary<int, Reservation> reservationExistsData = this.getReservationDataWithinRange(startingDate, endingDate, true);       // Reservations that happened in range

            // Get Rewards Points stats
            int currentPoints = this.getOutstandingRewardsPoints();     // Get total points at current time
            int netPointsAfterEndDate = this.sumRewardsPointsAcrossReservations(reservationsNowToEndDate);  // Get net points between end date and now
            int netPointsDuringPeriod = this.sumRewardsPointsAcrossReservations(reservationExistsData);     // Get net points between start and end date
            int pointsEarnedDuringPeriod = this.sumRewardsPointsAcrossReservations(reservationExistsData, false);   // Get positive points earned between start and end date

            // Add rewards points information to the report
            summaryReport +=    "Reward Points Summary\n" +
                                $"Rewards outstanding on date {startingDateString} - {currentPoints - netPointsAfterEndDate - netPointsDuringPeriod}\n" +
                                $"Rewards redeemed between {startingDateString} and {endingDateString} - {-1 * (netPointsDuringPeriod - pointsEarnedDuringPeriod)}\n" +
                                $"Rewards earned between {startingDateString} and {endingDateString} - {pointsEarnedDuringPeriod}\n" +
                                $"Rewards outstanding on date {endingDateString} - {currentPoints - netPointsAfterEndDate}\n\n";


            // Compute per hotel occupancy stats
            Dictionary<int, Hotel> hotels = this.getHotelData();    // Get all of the hotels

            // Values for accumulation pattern
            int totalRooms = 0;
            int totalReserved = 0;
            float totalRevenue = this.sumRevenueAcrossReservations(reservationExistsData);

            summaryReport += $"Occupancies and Revenue between {startingDateString} and {endingDateString}\n";  // Add header for next section

            // Loop through each hotel for occupancy stats
            foreach(var pair in hotels)
            {
                int key = pair.Key;     // Get hotelId
                Hotel data = pair.Value;    // Get hotel data object

                Dictionary<int, Room> rooms = this.getRoomsByHotelId(key);  // Get all rooms for this hotel
                Dictionary<int, Reservation> hotelReservations = new Dictionary<int, Reservation>(); // Create an empty dictionary for storing reservations

                foreach (var room in rooms)
                {
                    int roomId = room.Key;
                    
                    Dictionary<int, Reservation> roomReservs = this.getReservationsByRoom(roomId);
                    roomReservs.ToList().ForEach(x => hotelReservations.Add(x.Key, x.Value));
                }

                int roomsInHotel = rooms.Count; // Count the number of rooms
                //int reservedRoomsInHotel = this.countReservedRooms(rooms);  // Count how many are reserved
                float hotelRevenue = this.sumRevenueAcrossReservations(hotelReservations);
                int reservedRoomsInHotel = this.countReservedRooms(hotelReservations);
                int freeRoomsInHotel = roomsInHotel - reservedRoomsInHotel; // Calculate how many rooms are free

                totalRooms += roomsInHotel;
                totalReserved += reservedRoomsInHotel;  // Increment total by individual ammounts

                float occupancyRate = (float)reservedRoomsInHotel / roomsInHotel;   // Compute occupancy rate

                summaryReport += $"{data.getName()} Occupancy Rate - {occupancyRate} - ${hotelRevenue}\n";  // Add individual occupancy rates
            }

            summaryReport += $"Chain Occupancy Rate - {(float)totalReserved / totalRooms} - ${totalRevenue}\n\n";   // Add total occupancy rate data

            // Compute other statistics

            int totalReservations = this.countActiveReservations(reservationExistsData);                        // Total number of reservations that existed in this time slice
            int repeatCustomers = this.countRepeatCustomers(reservationExistsData);             // Total number of repeat customers in this time slice
            int upgrades = this.countUpgradedReservations(reservationExistsData);               // Total number of upgraded reservations in this time slice
            int cancellations = this.countCancelledReservations(reservationExistsData);         // Total number of cancelled reservations in this time slice

            float repeatPercent = (float)repeatCustomers / reservationExistsData.Count * 100;   // Calculate a percentage
            
            summaryReport += $"Customer Data from {startingDateString} to {endingDateString}\n" +   // Add last set of data to the report
                             $"Repeat customers - {repeatCustomers} ({repeatPercent}%)\n" +
                             $"Number of Upgrades - {upgrades}\n" +
                             $"Total Active Reservations - {totalReservations}\n" +
                             $"Total Cancellations - {cancellations}\n";

            return summaryReport;   // Return final generated string
        }
    }
}
