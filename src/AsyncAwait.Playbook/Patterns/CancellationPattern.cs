namespace AsyncAwait.Playbook.Patterns;

public static class CancellationPattern
{
    public static async Task<string> FetchWithTimeoutAsync(
        HttpClient client, string url, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(timeout);

        using var resp = await client.GetAsync(url, cts.Token);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadAsStringAsync(cts.Token);
    }
}