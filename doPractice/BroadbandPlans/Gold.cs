using System;

namespace BroadBandPlans
{
    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmout = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            if(discountPercentage < 0 && discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage));
            }

            _isSubscriptionValid = isSubscriptionValid;   
            _discountPercentage = discountPercentage;
        }

        public int GetBroadbandPlanAmount()
        {
            if (_isSubscriptionValid)
            {
                return PlanAmout - (PlanAmout * _discountPercentage / 100);
            }
            return PlanAmout;
        }
    }
}