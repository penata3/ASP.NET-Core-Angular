using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApplication.Server.Controllers
{

    public class HomeController: ApiController
    {

        public ActionResult<List<string>> Get() 
        {
            var users = new List<string>() { "Gosho", "Pesho" };

            return users;
        }

    }
}
