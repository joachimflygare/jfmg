using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
   public class LogInRepository
    {
        public static bool IsValid(string username, string password)
        {
            bool isValid = false;

            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if (user.Passsword == password)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
