using Microsoft.AspNetCore.Mvc;
using MyTweets.Contracts;
using MyTweets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTweets.Controllers
{
    public class PostsController : Controller
    {
        private List<Post> _posts = new List<Post>();

        public PostsController()
        {
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post() { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRouts.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}
