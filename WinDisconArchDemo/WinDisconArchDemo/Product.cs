using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDisconArchDemo
{
    /// <summary>
    /// Entity Class Product
    /// </summary>
    public class Product
    {
        #region Fields
            int prodID;
        #endregion

        #region Properties
        //CLR Properties
        public int ProdID
        {
            get { return prodID; }
            set 
            {  
                if(value < 0 || value > 999)
                {
                    throw new MyCustomException("Product ID is not Valid...");
                }
                else
                {
                    prodID = value;
                }
            }
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Desc { get; set; }

        #endregion
    }
}
