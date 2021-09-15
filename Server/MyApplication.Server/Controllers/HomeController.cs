namespace MyApplication.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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
