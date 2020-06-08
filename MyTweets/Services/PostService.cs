using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTweets.Data;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public class PostService : IPostService
    {
        private readonly TweetDbContext _dbContext;


        public PostService(TweetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> GetByIdAsync(Guid postId)
        {
            return await _dbContext.Posts.SingleOrDefaultAsync(i => i.Id == postId);
        }

        public async Task<bool> CreateAsync(Post newPost)
        {
            await _dbContext.Posts.AddAsync(newPost);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateAsync(Post postToUpdate)
        {
            _dbContext.Posts.Update(postToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(Guid postId)
        {
            var post = await GetByIdAsync(postId);

            if (post == null)
                return false;

            _dbContext.Posts.Remove(post);
            var removed = await _dbContext.SaveChangesAsync();
            return removed > 0;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }
    }
}
