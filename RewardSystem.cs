using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HotelManagementProject
{
    public class RewardSystem
    {
        private SqlConnection conn;
        private string connectionString = "Data Source=hotelmanagement375.database.windows.net;Initial Catalog=HotelManagement;User ID=hoteladmin;Password=Letmein123";
        public RewardSystem()
        {
            this.conn = new SqlConnection(this.connectionString);
        }
        public LinkedList<Reward> GetRewards(int maxCost)
        {
            LinkedList<Reward> rewards = new LinkedList<Reward>();
            this.conn.Open();   // Open the SQL connection
            SqlDataReader rdr = null;   // For reading data

            try
            {
                SqlCommand getReservations = new SqlCommand("SELECT * FROM Reward", this.conn);    // Sql command to get all reservations

                rdr = getReservations.ExecuteReader();  // Execute command

                while (rdr.Read())  // Loop through every entry in the table
                {
                    int rewardId = (int)rdr[0];
                    string description = (string)rdr[1];
                    int rewardCost = (int)rdr[2];
                    double discount = (double)rdr[3];

                    if(rewardCost <= maxCost)
                    {
                        Reward reward = new Reward(rewardId, description, rewardCost, discount);
                        rewards.AddLast(reward);
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

            return rewards;
        }
    }
}
