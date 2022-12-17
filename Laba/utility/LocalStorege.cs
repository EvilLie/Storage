using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba.utility
{
    internal class LocalStorege
    {
        private static User localUser;

        internal static User LocalUser { get => localUser; set => localUser = value; }
    }
}
