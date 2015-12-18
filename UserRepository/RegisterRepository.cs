using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class RegisterRepository
    {
        public static void Register(string firstname, string username, string gender, int age, string password, int visible)
        {
            using (var context = new datebookEntities())
            {
                Användare newUser = new Användare
                {
                    Namn = firstname,
                    
                 
            }
        }
    }
}
