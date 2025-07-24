using APILern.Domain.Enums;
using Microsoft.Identity.Client;

namespace APILern.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime PaymentDate { get; set; }
    public EnumPaymentStatus Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}