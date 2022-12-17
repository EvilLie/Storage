using Laba.dao.daoImpl;
using System.Collections.Generic;

namespace Laba.service.serviceImpl
{
    internal class UserService : SERVICE<User>
    {

        private UserDao userDao;

        public UserService()
        {
            userDao = new UserDao();
        }

        public List<User> correctAllList()
        {
            return userDao.allModels();
        }

        public bool correctDelete(User model)
        {
            return userDao.deleteModel(model.IdUser);
        }

        public User correctGetModel(int id)
        {
            return userDao.GetModelById(id);
        }

        public User correctGetModel(string name)
        {
            return userDao.GetModelByName(name);
        }

        public bool correctSave(User model)
        {
            return userDao.saveModel(model);
        }

        public bool correctUpdate(User model)
        {
            return userDao.updateModel(model);
        }

        public bool isUserTrue(User user)
        {
            List<User> users = correctAllList();
            foreach (User u in users)
            {
                if (u.NameUser.Equals(user.NameUser))
                    return true;
            }
            return false;
        }

        public bool isUserTrueWithPassword(User user)
        {
            List<User> users = correctAllList();
            foreach (User u in users)
            {
                if (u.NameUser.Equals(user.NameUser) && u.Pasword.Equals(user.Pasword))
                    return true;
            }
            return false;
        }
    }
}
