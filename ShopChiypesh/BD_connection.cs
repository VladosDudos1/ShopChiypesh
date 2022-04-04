using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChiypesh
{
    internal class BD_connection
    {
        public static ShopChiypeshEntities shop = new ShopChiypeshEntities();
        public static User user = new User();
    }
}
