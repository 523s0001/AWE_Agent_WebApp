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

        // =======================
        // 1) GET ALL
        // =======================
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
        public Product GetById(int id)
        {
            Product p = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT * FROM Product WHERE ProductID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    p = new Product
                    {
                        ProductID = (int)r["ProductID"],
                        SKU = r["SKU"].ToString(),
                        Name = r["Name"].ToString(),
                        Price = (decimal)r["Price"],
                        StockQty = (int)r["StockQty"],
                        ShortDesc = r["ShortDesc"] != DBNull.Value ? r["ShortDesc"].ToString() : "",
                        CategoryID = (int)r["CategoryID"],
                        BrandID = (int)r["BrandID"]
                    };
                }
            }

            return p;
        }


        // 2) INSERT PRODUCT
        public void Insert(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"INSERT INTO Product (SKU, Name, Price, StockQty, CategoryID, BrandID, ShortDesc)
                               VALUES (@SKU, @Name, @Price, @StockQty, @CategoryID, @BrandID, @ShortDesc)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SKU", p.SKU);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@StockQty", p.StockQty);
                cmd.Parameters.AddWithValue("@CategoryID", p.CategoryID);
                cmd.Parameters.AddWithValue("@BrandID", p.BrandID);
                cmd.Parameters.AddWithValue("@ShortDesc", p.ShortDesc ?? "");

                cmd.ExecuteNonQuery();
            }
        }

        // 3) UPDATE PRODUCT
        public void Update(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"UPDATE Product 
                               SET SKU=@SKU, Name=@Name, Price=@Price, StockQty=@StockQty,
                                   CategoryID=@CategoryID, BrandID=@BrandID, ShortDesc=@ShortDesc
                               WHERE ProductID=@ProductID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
                cmd.Parameters.AddWithValue("@SKU", p.SKU);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@StockQty", p.StockQty);
                cmd.Parameters.AddWithValue("@CategoryID", p.CategoryID);
                cmd.Parameters.AddWithValue("@BrandID", p.BrandID);
                cmd.Parameters.AddWithValue("@ShortDesc", p.ShortDesc ?? "");

                cmd.ExecuteNonQuery();
            }
        }

        // 4) DELETE PRODUCT
      
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "DELETE FROM Product WHERE ProductID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
