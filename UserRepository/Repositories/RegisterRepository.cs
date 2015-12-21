using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RegisterRepository
    {

        public static bool CheckUsername(string username)
        {
            using (var db = new MainDbEntities())
            {
                var usernameToCheck = db.Users.FirstOrDefault(x => x.Username.Equals(username));

                if (usernameToCheck == null)
                {
                    return false;
                }
                return true;
            }

        }

        public static void Register(string firstname, string username, string gender, int age, string password)
        {
            using (var db = new MainDbEntities())
            {
                Users newUser = new Users
                {
                    Name = firstname,
                    Username = username,
                    Gender = gender,
                    Age = age,
                    Passsword = password,
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
