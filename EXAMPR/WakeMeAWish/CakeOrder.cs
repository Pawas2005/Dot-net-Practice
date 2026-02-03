using System;

namespace WakeMeAWish;

public class CakeOrder
{
    private Dictionary<String, Double> orderMap = new Dictionary<string, double>();

    public void addOrderDetails(string orderId, double cakeCost)
    {
        orderMap[orderId] = cakeCost;
    }

    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        Dictionary<string, double> result = new Dictionary<string, double>();

        foreach (var item in orderMap)
        {
            if(item.Value > cakeCost)
            {
                result[item.Key] = item.Value;
            }
        }
        return result;
    }
}