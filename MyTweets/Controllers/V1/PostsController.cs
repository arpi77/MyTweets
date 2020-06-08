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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }

        [HttpGet(ApiRouts.Posts.GetById)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postService.GetByIdAsync(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPut(ApiRouts.Posts.UpdateById)]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid postId, [FromBody] UpdatePostRequest postToUpdate)
        {
            var post = new Post
            {
                Id = postId,
                Name = postToUpdate.Name
            };

            var updated = await _postService.UpdateAsync(post);

            if (!updated)
                return NotFound();

            return Ok(post);
        }

        [HttpDelete(ApiRouts.Posts.Delete)]
        public async Task<IActionResult> DeletePost([FromRoute] Guid postId)
        {
            var deleted = await _postService.DeleteAsync(postId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPost(ApiRouts.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest createPostRequest)
        {
            var post = new Post { Name = createPostRequest.Name };

            await _postService.CreateAsync(post);

            string baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string location = $"{baseUri}/{ApiRouts.Posts.GetById.Replace("{postId}", post.Id.ToString())}";

            var postResponse = new PostResponse { Id = post.Id };

            return Created(location, postResponse);
        }
    }
}
