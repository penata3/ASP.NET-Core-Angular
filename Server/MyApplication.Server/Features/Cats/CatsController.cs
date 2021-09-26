namespace MyApplication.Server.Features.Cats
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Features;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var catId = await this.catsService.CraeteCat(model, userId);
            return catId;
        }
    }
}
