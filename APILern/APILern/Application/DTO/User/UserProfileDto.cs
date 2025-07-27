using APILern.Application.DTO.Order;

namespace APILern.Application.DTO.User
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? NumberPhone { get; set; }
        public EnumUserRole Role { get; set; }
        public List<OrderResponseDto> Orders { get; set; } = new();
    }
}