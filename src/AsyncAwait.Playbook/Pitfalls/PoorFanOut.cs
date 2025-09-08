namespace AsyncAwait.Playbook.Pitfalls;

public static class PoorFanOut
{
    // BAD: sequential awaits
    public static async Task<List<string>> Bad_SequentialAsync(
        IEnumerable<Func<Task<string>>> calls)
    {
        var results = new List<string>();
        foreach (var call in calls)
            results.Add(await call()); // one-by-one
        return results;
    }

    // GOOD: parallel fan-out
    public static async Task<IReadOnlyList<string>> Good_WhenAllAsync(
        IEnumerable<Func<Task<string>>> calls)
    {
        var tasks = calls.Select(c => c());
        return await Task.WhenAll(tasks);
    }
}