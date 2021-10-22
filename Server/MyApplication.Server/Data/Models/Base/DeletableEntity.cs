﻿namespace MyApplication.Server.Data.Models.Base
{
    using System;

    public abstract class DeletableEntity : Entity,IDeletableEntity
    {
       public  DateTime? DeletedOn { get; set; }

        public bool isDeleted { get; set; }

        public string DeletedBy { get; set; }

    }
}
