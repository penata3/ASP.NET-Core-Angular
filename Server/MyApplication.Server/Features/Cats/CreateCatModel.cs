namespace MyApplication.Server.Features.Cats
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCatModel
    {
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
    }
}
