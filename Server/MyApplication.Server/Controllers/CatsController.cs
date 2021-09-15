namespace MyApplication.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Data;
    using MyApplication.Server.Data.Models;
    using MyApplication.Server.Models;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {

        //TODO: Refactor and add service layer
        private readonly MyApplicationDbContext dbContext;

        public CatsController(MyApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult<string> Get() 
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cat = new Cat()
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            await this.dbContext.Cats.AddAsync(cat);
            await this.dbContext.SaveChangesAsync();
            return cat.Id;         
        }
    }
}
