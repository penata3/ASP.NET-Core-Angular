namespace MyApplication.Server.Features.Cats
{
    using System.ComponentModel.DataAnnotations;

    public class CatListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
