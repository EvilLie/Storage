using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba.service
{
    internal interface SERVICE <T>
    {
        List<T> correctAllList();

        bool correctSave(T model);

        bool correctDelete(T model);

        bool correctUpdate(T model);

        T correctGetModel(int id);

        T correctGetModel(string name);
    }
}
