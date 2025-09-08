namespace AsyncAwait.Playbook.Pitfalls;

public static class BlockingWaits
{
    // BAD: may deadlock on UI/legacy ASP.NET due to SyncContext; always blocks a thread.
    public static string Bad_BlockingResult(Func<Task<string>> asyncProvider)
        => asyncProvider().Result; // or asyncProvider().Wait()

    // GOOD: make the call chain async all the way.
    public static async Task<string> Good_AwaitAsync(Func<Task<string>> asyncProvider)
        => await asyncProvider();
}