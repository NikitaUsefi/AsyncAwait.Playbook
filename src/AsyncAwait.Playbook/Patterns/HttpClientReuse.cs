namespace AsyncAwait.Playbook.Patterns;

public interface IGitHubClient
{
    Task<string> GetRootAsync(CancellationToken ct = default);
}

public sealed class GitHubClient : IGitHubClient
{
    private readonly HttpClient _http;

    public GitHubClient(HttpClient http) => _http = http;

    public async Task<string> GetRootAsync(CancellationToken ct = default)
    {
        using var resp = await _http.GetAsync("/", ct);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadAsStringAsync(ct);
    }

    // For console apps only (simple reuse):
    public static HttpClient CreateDefault()
    {
        var handler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(5) };
        var client = new HttpClient(handler) { BaseAddress = new Uri("https://api.github.com") };
        client.DefaultRequestHeaders.UserAgent.ParseAdd("AsyncAwait.Playbook");
        return client;
    }
}

/*
ASP.NET Core registration:

builder.Services.AddHttpClient<IGitHubClient, GitHubClient>(http =>
{
    http.BaseAddress = new Uri("https://api.github.com");
    http.DefaultRequestHeaders.UserAgent.ParseAdd("AsyncAwait.Playbook");
});
*/