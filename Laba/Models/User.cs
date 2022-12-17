using Laba.Models; 
using System;
using System.Collections.Generic;

namespace Laba
{
    internal class User : Object
    {
        private int idUser;

        private string nameUser;

        private string password;

        private int role;

        private HashSet<Order> orders = new HashSet<Order>();

        private HashSet<Product> products = new HashSet<Product>();


        public User()
        {
        }

        public User(int idUser, string nameUser, string pasword, int role, HashSet<Order> orders, HashSet<Product> products)
        {
            this.IdUser = idUser;
            this.NameUser = nameUser;
            this.Pasword = pasword;
            this.Role = role;
            this.Orders = orders;
            this.Products = products;
        }

        public int IdUser
        { get => idUser; set => idUser = value; }
        public string NameUser
        { get => nameUser; set => nameUser = value; }
        public string Pasword
        { get => password; set => password = value; }
        public int Role
        { get => role; set => role = value; }
        internal HashSet<Order> Orders { get => orders; set => orders = value; }
        internal HashSet<Product> Products { get => products; set => products = value; }

        override
        public string ToString()
        {
            return "id = " + idUser + " name = " + nameUser + " password " + password + "Role" + role;
        }
    }
}
