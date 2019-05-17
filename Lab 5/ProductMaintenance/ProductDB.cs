using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CustomerMaintenance;

namespace ProductMaintenance
{
    public class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            // I made the MMABooksDB class public for this. I'm
            // not sure if that was a good idea or not.
            SqlConnection connection = MMABooksDB.GetConnection();

            string query = @"
                SELECT *
                FROM Products
                WHERE ProductCode = @productCode;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@productCode", productCode);

            try
            {
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    Product product = new Product();

                    product.ProductCode = (string)reader["ProductCode"];
                    product.Description = (string)reader["Description"];
                    product.UnitPrice = (decimal)reader["UnitPrice"];
                    product.OnHandQuantity = (int)reader["OnHandQuantity"];

                    return product;
                }

                else
                {
                    return null;
                }
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            string query = @"
                UPDATE Products SET
                Description = @newDescription,
                UnitPrice = @newUnitPrice,
                OnHandQuantity = @newQuantity
                WHERE ProductCode = @productCode
                AND Description = @oldDescription
                AND UnitPrice = @oldUnitPrice
                AND OnHandQuantity = @oldQuantity;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@newDescription", newProduct.Description);
            command.Parameters.AddWithValue("@newUnitPrice", newProduct.UnitPrice);
            command.Parameters.AddWithValue("@newQuantity", newProduct.OnHandQuantity);

            command.Parameters.AddWithValue("@productCode", oldProduct.ProductCode);
            command.Parameters.AddWithValue("@oldDescription", oldProduct.Description);
            command.Parameters.AddWithValue("@oldUnitPrice", oldProduct.UnitPrice);
            command.Parameters.AddWithValue("@oldQuantity", oldProduct.OnHandQuantity);

            try
            {
                connection.Open();

                int rowCount = command.ExecuteNonQuery();

                if (rowCount > 0) return true;
                else return false;
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static bool AddProduct(Product newProduct)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            string actionQuery = @"
                INSERT INTO Products (ProductCode, Description, UnitPrice, OnHandQuantity)
                VALUES (@newProductCode, @newDescription, @newUnitPrice, @newQuantity);
            ";

            SqlCommand command = new SqlCommand(actionQuery, connection);

            command.Parameters.AddWithValue("@newProductCode", newProduct.ProductCode);
            command.Parameters.AddWithValue("@newDescription", newProduct.Description);
            command.Parameters.AddWithValue("@newUnitPrice", newProduct.UnitPrice);
            command.Parameters.AddWithValue("@newQuantity", newProduct.OnHandQuantity);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                // Returns whether or not the product was actually added.
                string getProduct = "SELECT * FROM Products WHERE ProductCode = @newProductCode";
                SqlCommand getProductRows = new SqlCommand(getProduct, connection);

                getProductRows.Parameters.AddWithValue("@newProductCode", newProduct.ProductCode);

                int rows = getProductRows.ExecuteNonQuery();

                if (rows > 0) return true;
                else return false;
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product toDelete)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            string query = @"
                DELETE FROM Products
                WHERE ProductCode = @productCode
                AND   Description = @description
                AND   UnitPrice = @unitPrice
                AND   OnHandQuantity = @quantity;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@productCode", toDelete.ProductCode);
            command.Parameters.AddWithValue("@description", toDelete.Description);
            command.Parameters.AddWithValue("@unitPrice", toDelete.UnitPrice);
            command.Parameters.AddWithValue("@quantity", toDelete.OnHandQuantity);

            try
            {
                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0) return true;
                else return false;
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
    }
}
