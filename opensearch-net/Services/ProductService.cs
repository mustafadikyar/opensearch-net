namespace opensearch_net.Services;

public class ProductService : IProductService
{
    protected const string OPENSEARCH_INDEX = "test";

    private readonly OpenSearchClient _opensearchClient;
    public ProductService(OpenSearchClient opensearchClient) => _opensearchClient = opensearchClient;

    public async Task<Product?> InsertAsync(Product? product)
    {
        var response = await _opensearchClient.IndexAsync(product, id => id.Index(OPENSEARCH_INDEX));

        if (!response.IsValid)
            return null;

        product!.Id = response.Id;
        return product;
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        var response = await _opensearchClient.GetAsync<Product>(id, id => id.Index(OPENSEARCH_INDEX));

        if (!response.IsValid)
            return null;

        return response.Source;
    }

    public async Task<IReadOnlyCollection<Product>?> FilterAsync(string text)
    {
        var request = new SearchRequest
        {
            From = 0,
            Size = 10, 
            Query = new TermQuery { Field = "productname", Value = text } || new MatchQuery { Field = "description", Query = text }
        };


        ISearchResponse<Product> response = await _opensearchClient.SearchAsync<Product>(request);


        if (!response.IsValid) 
            return null;

        return response.Documents.ToImmutableList();
    }
}
