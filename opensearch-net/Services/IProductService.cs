namespace opensearch_net.Services;

public interface IProductService
{
    Task<Product?> InsertAsync(Product? product);
    Task<Product?> GetByIdAsync(string id);
    Task<IReadOnlyCollection<Product>?> FilterAsync(string text);
}
