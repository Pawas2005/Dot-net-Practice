using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDisconArchDemo
{
    public interface IProductRepo:IRepo<Product> //Specific Interface
    {
        List<Product> ShowAllProductsByCategory(int catID);
        List<Product> ShowAllProductsByPricesAsc();
        List<Product> ShowAllProductsByPricesDesc();
        List<Product> GetTop3CostlyProduct();
        List<Product> GetTop3BudgetProduct();
    }
}
