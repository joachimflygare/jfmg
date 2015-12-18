using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        public Users GetFirst()
        {

            using (var context = new datebookEntities())
            {
                return context.Users.FirstOrDefault();
            }

        }

    }
}
