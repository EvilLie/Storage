using System;
using System.Data;

namespace Laba.Models
{
    internal class Order
    {
        private int idOrder;
 
        private string loginClient;
        private string nameProduct;
        private double price;
        private int idUser;

        public Order()
        {

        }

        public Order(int idOrder, string loginClient, string nameProduct, double price, int idUser)
        {
            this.IdOrder = idOrder;
          
            this.LoginClient = loginClient;
            this.NameProduct = nameProduct;
            this.Price = price;
            this.IdUser = idUser;
        }

        public int IdOrder { get => idOrder; set => idOrder = value; }
       
        public string LoginClient { get => loginClient; set => loginClient = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public double Price { get => price; set => price = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        override
        public string ToString()
        {
            return "id = " + idOrder + " name = " + loginClient + " price " + price;
        }
    }
}
