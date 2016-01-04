using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PostRepository
    {
        public static void Post(string message, int? postby, int? postto)
        {
            using (var db = new MainDbEntities())
            {
                var post = new Posts
                {
                    Post = message,
                    PostBy = postby,
                    PostTo = postto
                };
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public static List<Posts> getPost(int? userId)
        {
            using (var db = new MainDbEntities())
            {
                var posts = db.Posts.Where(x => x.PostTo == (userId)).ToList();
                return posts;
            }
        }
    }
}
