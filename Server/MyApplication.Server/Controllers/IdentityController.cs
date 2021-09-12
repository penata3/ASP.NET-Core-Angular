﻿namespace MyApplication.Server.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using MyApplication.Server.Data.Models;
    using MyApplication.Server.Models.Identity;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings appSettings;

        public IdentityController(UserManager<User> userManager,
             IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }

        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserModel model) 
        {

            var user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) {
                return Ok();
            }

            return BadRequest(result.Errors);

        }


        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginUserModel model) 
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            if (user == null) 
            {
                return BadRequest();
            }


            var isPasswordValid = await this.userManager.CheckPasswordAsync(user,model.Password);

            if (!isPasswordValid) 
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new
            {
                Token = encryptedToken
            };

        }

    }




}