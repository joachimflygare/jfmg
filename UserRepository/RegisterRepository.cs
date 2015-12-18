using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RegisterRepository
    {
        public static void Register(string firstname, string username, string gender, int age, string password)
        {
            using (var context = new datebookEntities())
            {
                Users newUser = new Users
                {
                    Name = firstname,
                    Username = username,
                    Gender = gender,
                    Age = age,
                    Passsword = password,
                };
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}
