namespace MyApplication.Server.Features.Cats
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Features;
    using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IEnumerable<CatResponseModel>> GetAll()
        {
            var allCats = await this.catsService.GetAllCatsAsync();
            return allCats;
        }



        [HttpGet]
        [Authorize]
        [Route("AllByUser")]
        public async Task<IEnumerable<CatResponseModel>> GetAllByUser(string userId)
        {
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var catsByUser = await this.catsService.CatsByUser(userId);
            return catsByUser;
        }


    }
}
