namespace MyApplication.Server.Features.Cats
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Features.Cats.Models;
    using MyApplication.Server.Infrastructure.Services;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly ICatsService catsService;
        private readonly ICurrentUserService currentUser;

        public CatsController(
            ICatsService catsService,
            ICurrentUserService currentUser)
        {
            this.catsService = catsService;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequestCatModel model)
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
            var userId = this.currentUser.GetId();

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
        [Route("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var catId = Id;

            var isDeleted = await this.catsService.Delete(userId, catId);

            if (!isDeleted) 
            {
                return BadRequest("Canot delete this object");
            }

            return Ok();

        }
    }
}
