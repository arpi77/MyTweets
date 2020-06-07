using Microsoft.AspNetCore.Mvc;
using MyTweets.Contracts;
using MyTweets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTweets.Contracts.Requests;
using MyTweets.Contracts.Responses;
using MyTweets.Services;

namespace MyTweets.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRouts.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetAll());
        }

        [HttpGet(ApiRouts.Posts.GetById)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetById(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRouts.Posts.UpdateById)]
        public IActionResult UpdatePost([FromRoute] Guid postId, [FromBody] UpdatePostRequest postToUpdate)
        {
            var post = new Post
            {
                Id = postId,
                Name = postToUpdate.Name
            };

            var updated = _postService.Update(post);

            if (!updated)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRouts.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest createPostRequest)
        {
            var post = new Post { Id = createPostRequest.Id };

            if (createPostRequest.Id == Guid.Empty)
                createPostRequest.Id = Guid.NewGuid();

            _postService.GetAll().Add(post);

            string baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string location = $"{baseUri}/{ApiRouts.Posts.GetById.Replace("{postId}", post.Id.ToString())}";

            var postResponse = new PostResponse { Id = post.Id };

            return Created(location, postResponse);
        }
    }
}
