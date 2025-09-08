namespace AsyncAwait.Playbook.Patterns;

public static class ConfigureAwaitGuidance
{
    // NOTE:
    // - Use ConfigureAwait(false) inside libraries to avoid resuming on a captured context.
    // - In ASP.NET Core there is no SynchronizationContext by default, so it's less critical in app code.
    public static async Task<string> LibraryStyleAsync(HttpClient http, string url, CancellationToken ct = default)
    {
        using var resp = await http.GetAsync(url, ct).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
    }
}