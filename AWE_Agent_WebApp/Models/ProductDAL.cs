using AWE_Agent_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AWE_Agent_WebApp.DAL
{
    public class ProductDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["AWEConn"].ConnectionString;

        public List<Product> GetAll()
        {
            var list = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Product
                    {
                        ProductID = (int)r["ProductID"],
                        SKU = r["SKU"].ToString(),
                        Name = r["Name"].ToString(),
                        Price = (decimal)r["Price"],
                        StockQty = (int)r["StockQty"],
                        ShortDesc = r["ShortDesc"] != DBNull.Value ? r["ShortDesc"].ToString() : "",
                        CategoryID = (int)r["CategoryID"],
                        BrandID = (int)r["BrandID"]
                    });
                }
            }
            return list;
        }
    }
}
