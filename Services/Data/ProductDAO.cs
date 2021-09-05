using TssCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TssCodingAssignment.Services.Data
{
    public class ProductDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CodeInterview;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal List<ProductModel> PopulateList()
        {
            List<ProductModel> products = new List<ProductModel>();

            //Prepare sql statement
            string sqlQuery = "SELECT * FROM dbo.Products";

            //Connect to db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    //Populate List with Products      
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Description = reader.GetString(2);
                        string Type = reader.GetString(3);
                        int Quantity = reader.GetInt32(4);
                        float Cost = (float)reader.GetDouble(5);
                        DateTime DateAdded = reader.GetDateTime(6);
                        string ImageUrl = reader.GetString(7);

                        ProductModel product = new ProductModel(Id, Name, Description, Type, Quantity, Cost, DateAdded, ImageUrl);
                        products.Add(product);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return products;
        }

        internal ProductModel GetProductById(int id)
        {
            ProductModel product = new ProductModel();

            //Prepare sql statement
            string sqlQuery = "SELECT * FROM dbo.Products WHERE Id = @Id";

            //Connect to db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    //Populate List with Products      
                    if (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Description = reader.GetString(2);
                        string Type = reader.GetString(3);
                        int Quantity = reader.GetInt32(4);
                        float Cost = (float)reader.GetDouble(5);
                        DateTime DateAdded = reader.GetDateTime(6);
                        string ImageUrl = reader.GetString(7);

                        product = new ProductModel(Id, Name, Description, Type, Quantity, Cost, DateAdded, ImageUrl);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return product;
        }

        internal ProductModel GetProductByName(string name)
        {
            ProductModel product = null;

            //Prepare sql statement
            string sqlQuery = "SELECT * FROM dbo.Products WHERE Name = @Name";

            //Connect to db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = name;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    //Populate List with Products      
                    if (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Description = reader.GetString(2);
                        string Type = reader.GetString(3);
                        int Quantity = reader.GetInt32(4);
                        float Cost = (float)reader.GetDouble(5);
                        DateTime DateAdded = reader.GetDateTime(6);
                        string ImageUrl = reader.GetString(7);

                        product = new ProductModel(Id, Name, Description, Type, Quantity, Cost, DateAdded, ImageUrl);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return product;
        }

        internal int AddProduct(ProductModel product)
        {
            int status = -1;

            //Prepare sql statement
            string sqlQuery = "INSERT INTO dbo.Products ([Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (@Name, @Desc, @Type, @Quantity, @Cost, @Date, @Img)";

            //Connect to db
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = product.Name;
                command.Parameters.Add("@Desc", System.Data.SqlDbType.NVarChar, 100).Value = product.Description;
                command.Parameters.Add("@Type", System.Data.SqlDbType.NVarChar, 50).Value = product.Type;
                command.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
                command.Parameters.Add("@Cost", System.Data.SqlDbType.Float).Value = product.Cost;
                command.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = product.DateAdded;
                command.Parameters.Add("@Img", System.Data.SqlDbType.NVarChar, 250).Value = product.ImageUrl;
                try
                {
                    connection.Open();
                    status = command.ExecuteNonQuery();
                    return status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return status;
            }
        }
    }
}