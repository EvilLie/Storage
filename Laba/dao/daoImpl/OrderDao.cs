using Laba.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Laba.dao.daoImpl
{
    internal class OrderDao : DAO<Order>
    {
        private MySqlConnection connection;

        private MySqlCommand command;

        private MySqlDataReader reader;
        public List<Order> allModels()
        {

            List<Order> list = new List<Order>();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM orders";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Order(reader.GetInt32("idOrder"), reader.GetString("loginClient"), reader.GetString("nameProduct"), reader.GetDouble("price"), reader.GetInt32("idUser")));
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
                string sql = "DELETE FROM orders WHERE idOrder ='" + id + "'";
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

        public Order GetModelById(int id)
        {
            Order order = new Order();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM orders WHERE idOrder= '" + id + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order.IdOrder = reader.GetInt32("idOrder");
                    order.LoginClient = reader.GetString("loginClient");
                    order.NameProduct = reader.GetString("nameProduct");
                    order.Price = reader.GetDouble("price");
                    order.IdUser = reader.GetInt32("idUsers");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return order;
        }

        public Order GetModelByName(string name)
        {
            Order order = new Order();
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "SELECT * FROM orders WHERE loginClient= '" + name + "'";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order.IdOrder = reader.GetInt32("idOrder");
                    order.LoginClient = reader.GetString("loginClient");
                    order.NameProduct = reader.GetString("nameProduct");
                    order.Price = reader.GetDouble("price");
                    order.IdUser = reader.GetInt32("idUsers");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return order;
        }

        public bool saveModel(Order model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "INSERT INTO orders (loginClient,nameProduct,price,idUser) VALUES ('" + model.LoginClient + "','" + model.NameProduct + "','" + model.Price + "','" + model.IdUser + "')";
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

        public bool updateModel(Order model)
        {
            try
            {
                connection = DB.OpenConnection();
                connection.Open();
                string sql = "UPDATE orders SET (loginClient,nameProduct,price,idUser)  VALUES ('" + model.LoginClient + "','" + model.NameProduct + "','" + model.Price + "','" + model.IdUser + "')" + " where idOrder = '" + model.IdOrder + "'";
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
