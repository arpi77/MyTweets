using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTweets.Data
{
    public class TweetDbContext : IdentityDbContext
    {
        public TweetDbContext(DbContextOptions<TweetDbContext> options)
            : base(options)
        {
        }
    }
}
