using System.Collections.Generic;

namespace MyTweets.Contracts.Responses
{
    public class AuthFailedResponse 
    {
        public IEnumerable<string> Errors { get; set; }
    }
}