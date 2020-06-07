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
                _posts.Add(new Post() { Id = Guid.NewGuid(), Name = $"Name {i + 1}" });
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

        public bool Update(Post postToUpdate)
        {
            bool exists = GetById(postToUpdate.Id) != null;

            if (!exists) return false;

            int index = _posts.FindIndex(p => p.Id == postToUpdate.Id);
            _posts[index] = postToUpdate;

            return true;
        }
    }
}
