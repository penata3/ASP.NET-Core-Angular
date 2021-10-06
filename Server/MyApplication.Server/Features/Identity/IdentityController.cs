namespace MyApplication.Server.Features.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Server.Data.Models;

    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;

        public IdentityController(UserManager<User> userManager,
             IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;

        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {

            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);

        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return BadRequest("Invalid Username or Password");
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Invalid Username or Password"); 
            }

            var token = this.identityService.GenerateJwtToken(user.Id, user.UserName);

            return new
            {
                Token = token
            };

        }

    }
}
