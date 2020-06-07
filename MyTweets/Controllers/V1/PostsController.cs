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

        [HttpPost(ApiRouts.Posts.Create)]
        public IActionResult Create([FromBody] Post post)
        {
            if (string.IsNullOrEmpty(post.Id))
                post.Id = Guid.NewGuid().ToString();

            _posts.Add(post);

            string baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string location = $"{baseUri}/{ApiRouts.Posts.GetById.Replace("{postId}", post.Id)}";
            return Created(location, post);
        }
    }
}
