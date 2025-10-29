using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    public static class GlobalState
    {
        public static string CurrentUserName { get; set; }
        public static string CurrentUserRole { get; set; }
    }
}
