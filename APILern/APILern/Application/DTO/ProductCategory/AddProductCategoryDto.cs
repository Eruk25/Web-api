using System.ComponentModel.DataAnnotations;

namespace APILern.Application.DTO
{
    public class AddProductCategoryDto
    {
        [Required]
        public required string Title { get; set; }
    }
}