using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject
{
    public class Reward
    {
        int rewardId;
        string description;
        int rewardCost;
        double discount;
        public Reward(int id, string d, int rc, double disc)
        {
            rewardId = id;
            description = d;
            rewardCost = rc;
            discount = disc;
        }
        public double applyDiscount(double cost)
        {
            if (discount > cost)
                return 0.0;
            else
                return cost - discount;
        }
        public int usePoints(int points)
        {
            if (rewardCost > points)
                return 0;
            else
                return points - rewardCost;
        }
        public override string ToString()
        {
            return description;
        }
    }
}
