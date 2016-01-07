using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositories.Repositories;
using datebook.Api.Models;
using Repositories;

namespace datebook.Api
{
    public class PostController : ApiController
    {

        [HttpPost]
        public void Post(PostModel model)
        {
            var posterProfile = ProfileRepository.GetProfile(model.PosterName);
            var posterId = posterProfile.UserId;
            PostRepository.Post(model.Post, posterId, model.PostTo);
        }

        [HttpGet]
        public List<PostModel> getPost(int userId)
        {
            var listOfPost = PostRepository.getPost(userId);
            var listOfPostModel = new List<PostModel>();

            foreach (var item in listOfPost)
            {
                var postModel = new PostModel
                {
                    Post = item.Post,
                    PostBy = item.PostBy
                };
                var profile = ProfileRepository.GetProfileByID(postModel.PostBy);
                postModel.PosterName = profile.Username;
                listOfPostModel.Add(postModel);
            }
            return listOfPostModel;
        }

    }
}
