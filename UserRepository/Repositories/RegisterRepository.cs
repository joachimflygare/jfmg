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
                var name = db.Users.FirstOrDefault(x => x.Username.Equals(username));

                if (name == null)
                {
                    return true;
                }
                return false;
            }

        }

        public static void Register(string name, string username, string gender, int age,int visible, string password)
        {
            Boolean boolVis;
            using (var db = new MainDbEntities())
               {
                    var user = db.Users.Create();
                    user.Name = name;
                    user.Username = username;
                    user.Gender = gender;
                    user.Age = age;
                    user.Passsword = password;
                    if (visible == 0)
                        boolVis = false;
                    else
                        boolVis = true;
                    user.Visible = boolVis;
                    db.Users.Add(user);
                    db.SaveChanges();
                      
            }
        }
    }
}
