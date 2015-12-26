﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    class SearchRepository
    {
        public static Users Search(string username)
        {
            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.Username.Equals(username));
                return user;
            }

        }
    }
}
