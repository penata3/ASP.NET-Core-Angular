namespace MyApplication.Server.Infrastructure.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUserService
    {

        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            this.user = contextAccessor.HttpContext?.User;
        }


        public string GetId()
        {
           return this.user?.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetUsername()
        {
            return this.user?.Identity?.Name;
        }
    }
}
