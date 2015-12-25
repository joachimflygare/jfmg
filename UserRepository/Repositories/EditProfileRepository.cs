using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class EditProfileRepository
    {
        public static Boolean EditUser(string currentUserName, string username, string name, string gender, int age, string info, int visible, string password)
        {
            if (RegisterRepository.CheckUsername(username))
            {
                using (var db = new MainDbEntities())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == currentUserName);
                    Boolean boolVis;
                    user.Username = username;
                    user.Gender = gender;
                    user.Age = age;
                    user.Info = info;
                    if (visible == 1)
                        boolVis = true;
                    else
                        boolVis = false;
                    user.Visible = boolVis;
                    user.Passsword = password;
                    db.SaveChanges();
                    return true;
                }
            }
   
            return false;

        }

    }
}
