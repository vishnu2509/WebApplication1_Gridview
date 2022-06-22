using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1_Gridview
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Unitprice { get; set; }
        public int OtyAvailable { get; set; }
    }
    public class ProductDataAccessLayer
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> listProducts = new List<Product>();

            string CS = ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Product", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product product = new Product();
                    product.Product_Id = Convert.ToInt32(rdr["Product_Id"]);
                    product.Product_Name = rdr["Product_Name"].ToString();
                    product.Unitprice = Convert.ToInt32(rdr["Unitprice"]);
                    product.OtyAvailable = Convert.ToInt32(rdr["OtyAvailable"]);

                    listProducts.Add(product);
                }
            }

            return listProducts;
        }


    }
}