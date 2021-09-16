namespace MyApplication.Server.Features.Home
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyApplication.Server.Features;
    using System.Collections.Generic;


    public class HomeController: ApiController
    {
        [Authorize]
        public ActionResult<List<string>> Get() 
        {
            var users = new List<string>() { "Gosho", "Pesho" };

            return users;
        }

    }
}
