using System;
using System.Collections.Generic;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(Guid postId);
        bool Update(Post postToUpdate);
        bool Delete(Guid postId);
    }
}