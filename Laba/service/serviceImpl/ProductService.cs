using Laba.dao.daoImpl;
using Laba.Models;
using System.Collections.Generic;

namespace Laba.service.serviceImpl
{
    internal class ProductService : SERVICE<Product>
    {
        ProductDao productDao;
        public ProductService()
        {
            productDao = new ProductDao();
        }

        public List<Product> correctAllList()
        {
            return productDao.allModels();
        }

        public bool correctDelete(Product model)
        {
            return productDao.deleteModel(model.IdProduct);
        }

        public Product correctGetModel(int id)
        {
            return productDao.GetModelById(id);
        }

        public Product correctGetModel(string name)
        {
            return productDao.GetModelByName(name);
        }

        public bool correctSave(Product model)
        {
            return productDao.saveModel(model);
        }

        public bool correctUpdate(Product model)
        {
            return productDao.updateModel(model);
        }
    }
}
