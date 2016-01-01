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
        public static void AddFriend(Friends model)
        {
            using (var db = new MainDbEntities())
            {
                db.Friends.Add(model);
                db.SaveChanges();
            }

        }

        public static List<Friends> GetFriends(int userId)
        {
            using (var db = new MainDbEntities())
            {
                var friends = db.Friends
                    .Where(x => x.Accepted == true && (x.FriendId == userId || x.UserId == userId))
                    .Include(x => x.Users)
                    .Include(x => x.Users1)
                    .ToList();

                return friends;
            }
        }

        public static List<Friends> GetRequests(int userId)
        {
            using (var db = new MainDbEntities())
            {
                var requests = db.Friends
                    .Where(x => x.Accepted == false && (x.FriendId == userId || x.UserId == userId))
                    .Include(x => x.Users)
                    .Include(x => x.Users1)
                    .ToList();


                return requests;
            }
        }

        public static Friends Relation(int userid, int friendId)
        {
            using (var db = new MainDbEntities())
            {
                Friends friend = db.Friends.FirstOrDefault(x => (x.FriendId == friendId && x.UserId == userid) || (x.UserId == friendId && x.FriendId == userid));
                return friend;
            }
        }

        public static void AcceptFriend(int? userId, int? friendId)
        {
            using (var db = new MainDbEntities())
            {
                Friends friend = db.Friends.FirstOrDefault(x => (x.UserId == userId && x.FriendId == friendId) || (x.UserId == friendId && x.FriendId == userId));
                friend.Accepted = true;
                db.SaveChanges();
            }
        }

        public static int GetPending(int? userId)
        {
            using (var db = new MainDbEntities())
            {
                int pendningRequests = db.Friends.Count(x => x.FriendId == userId && !x.Accepted);

                return pendningRequests;
            }
        }
    }
}
