namespace APILern.Domain.Entities;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
    public List<Product> Products { get; set; }
}
