namespace opensearch_net.Extensions;

public static class OpensearchExtension
{
    public static void AddOpensearch(this IServiceCollection services, IConfiguration configuration)
    {
        var node = new Uri(configuration.GetSection("Opensearch")["Url"]!);
        var config = new ConnectionSettings(node);
        var client = new OpenSearchClient(config);

        services.AddSingleton(client);
    }
}
