using System.Data;

namespace Laba.Models
{
    internal class Product
    {
        private int idProduct;
        private string nameProduct;
        private double cost;
        private int idUser;

        public Product()
        { 

        }

        public Product(int idProduct, string nameProduct, double cost, int idUser)
        {
            this.idProduct = idProduct;
            this.nameProduct = nameProduct;
            this.cost = cost;
            this.idUser = idUser;
        }

        public int IdProduct { get => idProduct; set => idProduct = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public double Cost { get => cost; set => cost = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        
        override
      public string ToString()
        {
            return "id = " + idProduct + " name = " + nameProduct  + "Cost = " + cost;
        }
    }
}
