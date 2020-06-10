using System.Threading.Tasks;
using MyTweets.Domain;

namespace MyTweets.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}