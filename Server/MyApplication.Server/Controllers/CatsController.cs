namespace MyApplication.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Security.Claims;

    public class CatsController : ApiController
    {

        [Authorize]
        public ActionResult<string> Get()
        {
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return userId;
        }
    }
}
