namespace MyApplication.Server.Features.Cats.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CatDetailsServiceModel : CatListingServiceModel
    {
        [Required]
        public string UserId { get; set; }
    }
}
