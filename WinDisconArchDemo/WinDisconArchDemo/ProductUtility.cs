using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinDisconArchDemo
{
    public class ProductUtility : IProductRepo
    {
        IDbConnection con;
        SqlDataAdapter adap1;
        DataSet ds;

        public ProductUtility()
        {
            con = new SqlConnection();
            con.ConnectionString="Server=.\\SQLEXPRESS;Integrated Security=true;Database=LPU_DB;TrustServerCertificate=true";

        }

        public bool AddData(Product obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTop3BudgetProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTop3CostlyProduct()
        {
            throw new NotImplementedException();
        }

        public Product SearchByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAll()
        {
            List<Product> prodList = null;

            try
            {
                adap1 = new SqlDataAdapter("Select * from Products", (SqlConnection)con);
                adap1.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                ds = new DataSet();
                adap1.Fill(ds, "Prod");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    prodList = new List<Product>();
                    foreach(DataRow drow in ds.Tables["Prod"].Rows)
                    {
                        Product p1 = new Product()
                        {
                            ProdID = Int32.Parse(drow[0].ToString()),
                            Name = drow[1].ToString(),
                            Category = drow[2].ToString(),
                            Price = float.Parse(drow[3].ToString()), 
                            Desc = drow[4].ToString()
                        };
                        prodList.Add(p1);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading products: " + ex.Message, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return prodList;
        }

        public List<Product> ShowAllProductsByCategory(int catID)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAllProductsByPricesAsc()
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAllProductsByPricesDesc()
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(int id, Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
