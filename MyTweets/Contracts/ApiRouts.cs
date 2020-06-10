using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTweets.Contracts
{
    public static class ApiRouts
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Create = Base + "/posts";
            public const string GetById = Base + "/posts/{postId}";
            public const string UpdateById = Base + "/posts/{postId}";
            public const string Delete = Base + "/posts/{postId}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
    }
}
