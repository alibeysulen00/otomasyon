using Microsoft.EntityFrameworkCore;
using otomasyon_exmp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon_exmp
{
    public sealed class DBHelper
    {
        public static UserDBContext Instance;

        public static async Task InitDb()
        {
            /*
             * For AppDB run:
             * Add-Migration AppDbInitialCreate -Context AppDbContext -OutputDir "Migrations/AppDb"
             * Update-Database -Context AppDbContext
             */
            Instance = new UserDBContext();

            var user = await Instance.Users.FirstOrDefaultAsync();

            if (user == null)
            {
                var admin = new User
                {
                    Password = "6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b",
                    Username = "admin"                   
                };
                Instance.Users.Add(admin);
                await Instance.SaveChangesAsync();
            }
        }
    }
}