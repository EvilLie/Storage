using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba.dao
{
    internal interface DAO <T>
    {
        T GetModelById (int id);

        T GetModelByName (string name);

        bool saveModel(T model);

        bool deleteModel(int id);

        bool updateModel(T model);

        List<T> allModels();

    }
}
