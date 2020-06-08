using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid postId);
        Task<bool> CreateAsync(Post newPost);
        Task<bool> UpdateAsync(Post postToUpdate);
        Task<bool> DeleteAsync(Guid postId);
    }
}