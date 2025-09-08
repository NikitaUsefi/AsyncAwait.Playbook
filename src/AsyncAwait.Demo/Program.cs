namespace AsyncAwait.Demo;

using AsyncAwait.Playbook.Patterns;

internal static class Program
{
    private static async Task Main()
    {
        using var http = GitHubClient.CreateDefault();
        var ok = await new GitHubClient(http).GetRootAsync();
        Console.WriteLine($"GitHub OK: {ok.Length} chars");

        // quick fan-out demo
        var urls = new[] { "https://example.com" };
        var client = new HttpClient();
        var tasks = urls.Select(u => client.GetStringAsync(u));
        var results = await Task.WhenAll(tasks);
        Console.WriteLine($"Fetched {results.Length} pages in parallel.");
    }
}