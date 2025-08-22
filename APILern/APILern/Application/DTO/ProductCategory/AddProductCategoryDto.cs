using System.ComponentModel.DataAnnotations;

namespace APILern.Application.DTO
{
    public class AddProductCategoryDto
    {
        public required string Title { get; set; }
    }
}