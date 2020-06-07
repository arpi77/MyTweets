using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public class PostService : IPostService
    {
        private List<Post> _posts = new List<Post>();

        public PostService()
        {
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post() { Id = Guid.NewGuid() });
            }
        }

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(Guid postId)
        {
            return _posts.SingleOrDefault(i => i.Id == postId);
        }
    }
}
