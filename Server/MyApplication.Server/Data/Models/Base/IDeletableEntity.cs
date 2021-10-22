namespace MyApplication.Server.Data.Models.Base
{
    using System;

    public interface IDeletableEntity : IEntity
    {
        
        DateTime? DeletedOn { get; set; }

        bool isDeleted { get; set; }

        string DeletedBy { get; set; }

    }
}
