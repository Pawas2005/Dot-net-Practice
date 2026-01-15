using System;

namespace BroadBandPlans
{
    class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;

        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            _broadbandPlans = broadbandPlans ?? throw new ArgumentNullException(nameof(broadbandPlans));
        }

        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            IList<Tuple<string, int>> res = new List<Tuple<string, int>>();

            if(_broadbandPlans == null)
            {
                throw new ArgumentNullException(nameof(_broadbandPlans));
            }

            foreach(var plan in _broadbandPlans)
            {
                string planType = plan.GetType().Name;
                int planAmount = plan.GetBroadbandPlanAmount();

                res.Add(Tuple.Create(planType, planAmount));
            }
            return res;
        }
    }
}