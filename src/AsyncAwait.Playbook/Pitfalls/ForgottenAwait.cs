namespace AsyncAwait.Playbook.Pitfalls;

public static class ForgottenAwait
{
    // BAD: silently drops exceptions; task may outlive calling scope.
    public static void Bad_FireAndForget(Task task) => _ = task;

    // BETTER: observe exceptions explicitly (only for truly background work).
    public static void Better_FireAndForget(Task task, Action<Exception> onError)
        => task.ContinueWith(t => onError(t.Exception!), TaskContinuationOptions.OnlyOnFaulted);

    // GOOD: usually... just await it.
    public static async Task Good_JustAwait(Task task) => await task;
}