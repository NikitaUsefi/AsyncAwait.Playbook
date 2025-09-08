namespace AsyncAwait.Playbook.Pitfalls;

public static class SyncOverAsync
{
    // BAD: wrapping async in Task.Run + blocking is still sync-over-async.
    public static string Bad_GetString(Task<string> t)
        => t.GetAwaiter().GetResult();

    // GOOD: async all the way (async Main is allowed in .NET).
    public static async Task<string> Good_GetString(Task<string> t)
        => await t;
}