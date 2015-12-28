using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FriendRepository
    {
        public static List<Friends> GetFriends(int userId)
        {
            using (var db = new MainDbEntities())
            {
                var result = db.Friends
                    .Where(x => x.Accepted == true && (x.FriendId == userId || x.UserId== userId))
                    .Include(x => x.Users)
                    .Include(x => x.Users1)
                    .ToList();

                return result;

            }
        }

        public static Boolean Relation(int userid, int friendId)
        {
            Boolean friends = false;

            using (var db = new MainDbEntities())
            {
                if (db.Friends.FirstOrDefault(x => (x.FriendId == friendId && x.UserId == userid) || (x.UserId == friendId && x.FriendId == userid)) != null)
                    friends = true;

                return friends;
            }
        }

    }
}
