using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public class CosmosPostService : IPostService
    {
        private readonly ICosmosStore<CosmosPostDto> _cosmosStore;

        public CosmosPostService(ICosmosStore<CosmosPostDto> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = await _cosmosStore.Query().ToListAsync();

            return posts.Select(p => new Post {Id = Guid.Parse(p.Id), Name = p.Name}).ToList();
        }

        public async Task<Post> GetByIdAsync(Guid postId)
        {
            var post = await _cosmosStore.FindAsync(postId.ToString(), postId.ToString());

            return post == null
                ? null
                : new Post()
                {
                    Id = Guid.Parse(post.Id),
                    Name = post.Name
                };
        }


        public async Task<bool> CreateAsync(Post newPost)
        {
            var cosmosPostDto = new CosmosPostDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newPost.Name
            };

            var cosmosResponse = await _cosmosStore.AddAsync(cosmosPostDto);


            return cosmosResponse.IsSuccess;
        }

        public async Task<bool> UpdateAsync(Post postToUpdate)
        {
            var cosmosPostDto = new CosmosPostDto()
            {
                Id = postToUpdate.Id.ToString(),
                Name = postToUpdate.Name
            };

            var response = await _cosmosStore.UpdateAsync(cosmosPostDto);

            return response.IsSuccess;
        }

        public async Task<bool> DeleteAsync(Guid postId)
        {
            var response = await _cosmosStore.RemoveByIdAsync(postId.ToString(), postId.ToString());

            return response.IsSuccess;
        }
    }
}