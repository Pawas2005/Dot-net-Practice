using System;
namespace ProdInvMgmt;

public class Inventory : IInventory
{
    private List<IProduct> _products = new List<IProduct>();

    // AddProduct
    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    // RemoveProduct
    public void RemoveProduct(IProduct product)
    {
        _products.Remove(product);
    }

    // CalculateTotalValue
    public int CalculateTotalValue()
    {
        int total = 0;
        foreach(IProduct p in _products)
        {
            total += p.Stock * p.Price;
        }
        return total;
    }

    //GetProductsByCategory
    public List<IProduct> GetProductsByCategory(string Category)
    {
        List<IProduct> result = new List<IProduct>();

        foreach(IProduct p in _products)
        {
            if(p.Category == Category)
            {
                result.Add(p);
            }
        }
        return result;
    }

    // GetProductsByCategoryWithCount
    public List<(string, int)> GetProductsByCategoryWithCount()
    {
        List<(string, int)> res = new List<(string, int)>();

        foreach(IProduct p in _products)
        {
            bool found = false;
            for(int i = 0; i < res.Count; i++)
            {
                if(res[i].Item1 == p.Category)
                {
                    res[i] = (res[i].Item1, res[i].Item2 + 1);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                res.Add((p.Category, 1));
            }
        }
        return res;
    }

    // SearchProductsByName
    public List<IProduct> SearchProductsByName(string Name)
    {
        List<IProduct> res = new List<IProduct>();

        foreach(IProduct p in _products)
        {
            if (p.Name.ToLower().Contains(Name.ToLower()))
            {
                res.Add(p);
            }
        }
        return res;
    }

    // GetAllProductsByCategory
    public List<(string, List<IProduct>)> GetAllProductsByCategory()
    {
        List<(string, List<IProduct>)> res = new List<(string, List<IProduct>)>();

        foreach(IProduct p in _products)
        {
            bool found = false;
            for(int i = 0; i < res.Count; i++)
            {
                if(res[i].Item1 == p.Category)
                {
                    res[i].Item2.Add(p);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                List<IProduct> list = new List<IProduct>();
                list.Add(p);
                res.Add((p.Category, list));
            }
        }

        return res;
    }
}