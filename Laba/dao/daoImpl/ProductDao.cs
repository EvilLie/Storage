using Laba.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba.dao.daoImpl
{

    internal class ProductDao : DAO<Product>
    {
        private MySqlConnection connection;

        private MySqlCommand command;

        private MySqlDataReader reader;
        public List<Product> allModels()
        {
            List<Product> list = new List<Product>();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM products";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Product(reader.GetInt32("idProduct"), reader.GetString("nameProduct"), reader.GetDouble("cost"), reader.GetInt32("idUser")));

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public bool deleteModel(int id)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "DELETE FROM products WHERE idProduct ='" + id + "'";
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public Product GetModelById(int id)
        {
            Product product = new Product();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM products WHERE idProduct= '" + id + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.IdProduct = reader.GetInt32("idProduct");
                    product.NameProduct= reader.GetString("nameProduct");
                    product.Cost = reader.GetDouble("cost");
                    product.IdUser = reader.GetInt32("idUsers");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return product;
        }

        public Product GetModelByName(string name)
        {
            Product product = new Product();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM products WHERE nameProduct= '" + name + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.IdProduct = reader.GetInt32("idProduct");
                    product.NameProduct = reader.GetString("nameProduct");
                    product.Cost = reader.GetDouble("cost");
                    product.IdUser = reader.GetInt32("idUsers");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return product;
        }

        public bool saveModel(Product model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "INSERT INTO products (nameProduct,cost,idUser) VALUES ('"+ model.NameProduct + "','" + model.Cost + "','" + model.IdUser + "')";
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool updateModel(Product model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "UPDATE products SET (nameProduct,cost,idUser)  VALUES ('" + model.NameProduct +  "','" + model.Cost + "','" + model.IdUser + "')" + " where idProduct = '" + model.IdProduct + "'";
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
