using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    class Reservation
    {
        private int reservationId;

        private DateTime startDate;
        private DateTime endDate;

        private int rewardPointsEarned;
        private int rewardPointsSpent;
        private float cost;

        public Reservation(int reservationId, DateTime startDate, DateTime endDate, float cost, int rewardPointsEarned, int rewardPointsSpent)
        {
            this.reservationId = reservationId;

            this.startDate = startDate;
            this.endDate = endDate;

            this.cost = cost;
            this.rewardPointsEarned = rewardPointsEarned;
            this.rewardPointsSpent = rewardPointsSpent;
        }

        public int getId()
        {
            return this.reservationId;
        }

        public DateTime getStartDate()
        {
            return this.startDate;
        }

        public DateTime getEndDate()
        {
            return this.endDate;
        }

        public float getCost()
        {
            return this.cost;
        }

        public int getRewardPointsEarned()
        {
            return this.rewardPointsEarned;
        }

        public int getRewardPointsSpent()
        {
            return this.rewardPointsSpent;
        }
    }
}
