using Laba.dao.daoImpl;
using Laba.Models;
using System.Collections.Generic;

namespace Laba.service.serviceImpl
{
    internal class OrderService : SERVICE<Order>
    {
        private OrderDao orderDao;

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
    }
}
