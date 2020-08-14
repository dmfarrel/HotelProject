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
        private DateTime madeDate;

        private int rewardPointsEarned;
        private int rewardPointsSpent;
        private float cost;

        private bool cancelled;
        private bool upgraded;

        public Reservation(int reservationId, DateTime startDate, DateTime endDate, DateTime madeDate, float cost, int rewardPointsEarned, int rewardPointsSpent, bool cancelled, bool upgraded)
        {
            this.reservationId = reservationId;

            this.startDate = startDate;
            this.endDate = endDate;
            this.madeDate = madeDate;

            this.cost = cost;
            this.rewardPointsEarned = rewardPointsEarned;
            this.rewardPointsSpent = rewardPointsSpent;

            this.cancelled = cancelled;
            this.upgraded = upgraded;
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

        public DateTime getMadeDate()
        {
            return this.madeDate;
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

        public bool isCancelled()
        {
            return this.cancelled;
        }

        public bool isUpgraded()
        {
            return this.upgraded;
        }
    }
}
