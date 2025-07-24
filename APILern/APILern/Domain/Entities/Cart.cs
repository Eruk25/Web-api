namespace APILern.Domain.Entities;

public class Cart
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public User? Client { get; set; }
    public List<CartItem> Items { get; set; }
}
