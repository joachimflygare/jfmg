﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public class LogInRepository
    {
        public static User LogIn(string username, string password)
        {
            using (var context = new MainDbEntities())
            {
                return context.Users.FirstOrDefault(
                    x => x.Username.Equals(username)
                    && x.Passsword.Equals(password));

            }

        }

    }
}
