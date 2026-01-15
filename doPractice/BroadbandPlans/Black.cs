using System;

namespace BroadBandPlans
{
    class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;

        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            if(discountPercentage < 0 && discountPercentage > 50)
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
                return PlanAmount - (PlanAmount * _discountPercentage / 100);
            }
            return PlanAmount;
        }
    }
}