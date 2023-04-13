using E_Commerce.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Common.Consts
{
    public static class RoleTypeConst
    {
        public static Dictionary<int, string> RoleAppUserTypePairs = new Dictionary<int, string>();

        static RoleTypeConst()
        {
            RoleAppUserTypePairs.Add((int)AppUserType.Customer, "Customer");
            RoleAppUserTypePairs.Add((int)AppUserType.Admin, "Admin");
            RoleAppUserTypePairs.Add((int)AppUserType.Supplier, "Supplier");
        }
        
    }

}
