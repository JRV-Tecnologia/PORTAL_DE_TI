using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PORTAL_DE_TI.Services
{
    public interface IUserResolverService
    {
        string GetUser();
    }

    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _accessor;
        public UserResolverService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
 

        public string GetUser()
        {
            
            //return _accessor.HttpContext.User?.Identity?.Name;

            //return accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var username = _accessor?.HttpContext?.User?.Identity?.Name;
            return username ?? "unknown";
        }
    }
}