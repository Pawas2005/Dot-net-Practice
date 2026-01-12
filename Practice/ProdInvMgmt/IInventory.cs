using System;
namespace ProdInvMgmt;

public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<IProduct> GetProductsByCategory(string Category);
    List<(string, int)> GetProductsByCategoryWithCount();
    List<IProduct> SearchProductsByName(string Name);
    List<(string, List<IProduct>)> GetAllProductsByCategory();
}