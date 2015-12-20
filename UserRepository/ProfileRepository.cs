using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProfileRepository
    {
        public User GetFirst()
        {
            using (var context = new MainDbEntities())
            {
                return context.Users.FirstOrDefault();
            }

        }

    }
}
