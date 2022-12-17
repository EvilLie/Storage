using Laba.dao.daoImpl;
using Laba.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laba.service.serviceImpl
{
    internal class OrderService : SERVICE<Order>
    {
        private OrderDao orderDao;
        static string filename = "order.txt";
        public OrderService()
        {
            orderDao = new OrderDao();
        }

        public List<Order> correctAllList()
        {
            return orderDao.allModels();
        }

        public bool correctDelete(Order model)
        {
            return orderDao.deleteModel(model.IdOrder);
        }

        public Order correctGetModel(int id)
        {
            return orderDao.GetModelById(id);
        }

        public Order correctGetModel(string name)
        {
            return orderDao.GetModelByName(name);
        }

        public bool correctSave(Order model)
        {
            return orderDao.saveModel(model);
        }

        public bool correctUpdate(Order model)
        {
            return orderDao.updateModel(model);
        }
        public void createRecord()
        {
            List<Order> orders = correctAllList();
            double price = 0;
            StreamWriter sw = new StreamWriter(filename);
            foreach (Order o in orders)
            {
                sw.WriteLine(o.ToString()+"\n");
                price += o.Price;
                sw.Flush();
            }
            sw.Write(price);
            sw.Flush();
            sw.Close();
        }
    }
}
