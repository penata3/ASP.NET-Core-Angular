namespace MyApplication.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using MyApplication.Server.Data.Models.Base;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser,IEntity
    {
       
        public DateTime CreatedOn { get ; set ; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
