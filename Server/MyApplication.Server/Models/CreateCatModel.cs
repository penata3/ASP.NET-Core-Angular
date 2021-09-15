using System.ComponentModel.DataAnnotations;

namespace MyApplication.Server.Models
{
    public class CreateCatModel
    {
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
    }
}
