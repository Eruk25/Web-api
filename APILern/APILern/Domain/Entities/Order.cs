using APILern.Domain.Enums;
using Microsoft.Identity.Client;

namespace APILern.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime PaymentDate { get; set; }
    public EnumPaymentStatus Status { get; set; }
}