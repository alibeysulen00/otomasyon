using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using otomasyon_exmp.Authorization;
namespace otomasyon_exmp
{
    internal class SessionHelper
    {
        public static User CurrentUser;

        public static bool IsLoggedIn => CurrentUser != null;
    }
}
