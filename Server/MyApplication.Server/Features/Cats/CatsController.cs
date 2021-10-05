namespace MyApplication.Server.Features.Cats
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Features.Cats.Models;
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

        //[HttpGet]
        //public async Task<IEnumerable<CatListingServiceModel>> GetAll()
        //{
        //    var allCats = await this.catsService.GetAllCatsAsync();
        //    return allCats;
        //}

        

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CatListingServiceModel>> GetAllByUser()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var catsByUser = await this.catsService.CatsByUserAsync(userId);
            return catsByUser;
        }


        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        {
            var cat = await this.catsService.ById(id);

            if (cat == null)
            {
                BadRequest("No such post");
            }

            return cat;
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isUpdated = await this.catsService.Update(userId, model.Id, model.Description);

            if (!isUpdated) 
            {
                return BadRequest("Enity canot be updated");
            }

            return Ok();
        }


        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int catId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isDeleted = await this.catsService.Delete(userId, catId);

            if (!isDeleted) 
            {
                return BadRequest("Canot delete this object");
            }

            return Ok();

        }
    }
}
