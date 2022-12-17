using Laba.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Laba.dao.daoImpl
{
    internal class UserDao : DAO<User>
    {
        private MySqlConnection connection;

        private MySqlCommand command;

        private MySqlDataReader reader;

        public List<User> allModels()
        {
            List<User> list = new List<User>();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM users";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new User(reader.GetInt32("idUser"), reader.GetString("nameUser"), reader.GetString("password"), reader.GetInt32("role"), null, null));
                  
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
                string sql = "DELETE FROM users WHERE idUser ='" + id + "'";
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

        public User GetModelById(int id)
        {
            User user = null;
            HashSet<Order> orders = new HashSet<Order>();
            HashSet<Product> products = new HashSet<Product>();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM users as u left join orders o on u.idUser = o.idUser left join product p on p.idUser = u.idUser  where u.idUser ='" + id + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    user.IdUser = reader.GetInt32("idUser");
                    user.NameUser = reader.GetString("nameUser");
                    user.Pasword = reader.GetString("password");
                    user.Role = reader.GetInt32("role");
                    orders.Add(new Order(reader.GetInt32("idOrder"), reader.GetString("loginClient"), reader.GetString("nameProduct"), reader.GetDouble("price"), reader.GetInt32("idUser")));
                    products.Add(new Product(reader.GetInt32("idProduct"), reader.GetString("nameProduct"), reader.GetDouble("cost"), reader.GetInt32("idUser")));
                }
                user.Orders = orders;
                user.Products = products;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public User GetModelByName(string name)
        {
            User user = new User();
            HashSet<Order> orders = new HashSet<Order>();
            HashSet<Product> products = new HashSet<Product>();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM users WHERE nameUser= '" + name + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.IdUser = reader.GetInt32("idUser");
                    user.NameUser = reader.GetString("nameUser");
                    user.Pasword = reader.GetString("password");
                    user.Role = reader.GetInt32("role");
                    orders.Add(new Order(reader.GetInt32("idOrder"), reader.GetString("loginClient"), reader.GetString("nameProduct"), reader.GetDouble("price"), reader.GetInt32("idUser")));
                    products.Add(new Product(reader.GetInt32("idProduct"), reader.GetString("nameProduct"), reader.GetDouble("cost"), reader.GetInt32("idUser")));
                }
                user.Orders = orders;
                user.Products = products;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public bool saveModel(User model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "INSERT INTO users (nameUser,password,role) VALUES ('"  + model.NameUser + "','" + model.Pasword + "','" + model.Role + "')";
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

        public bool updateModel(User model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "UPDATE users SET (nameUser,password,role)  VALUES ('" + model.NameUser + "','" + model.Pasword + "','" + model.Role + "')" + " where idUser='" + model.IdUser + "'";
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
