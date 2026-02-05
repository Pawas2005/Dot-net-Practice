using System;

namespace WakeMeAWish;

public class CakeOrder
{
    private Dictionary<String, Double> orderMap = new Dictionary<string, double>();

    public Dictionary<String, Double> OrderMap
    {
        get { return orderMap; }
        set { orderMap = value; }
    }

    public void addOrderDetails(string orderId, double cakeCost)
    {
        if (!orderMap.ContainsKey(orderId))
        {
            orderMap.Add(orderId, cakeCost);
        }
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