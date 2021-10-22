namespace MyApplication.Server.Features.Cats.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCatRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
