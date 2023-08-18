namespace opensearch_net.Models;

public class Product
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
