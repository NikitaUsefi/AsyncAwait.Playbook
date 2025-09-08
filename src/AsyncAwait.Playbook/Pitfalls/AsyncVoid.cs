namespace AsyncAwait.Playbook.Pitfalls;

public static class AsyncVoid
{
    // BAD: exceptions crash the process; caller cannot await or handle errors.
    public static async Task Bad_DoWorkAsync()
    {
        await Task.Delay(10);
        throw new InvalidOperationException("Boom");
    }

    // GOOD: return Task, let callers await and handle errors.
    public static async Task Good_DoWorkAsync()
    {
        await Task.Delay(10);
        // throw if needed; caller can catch
    }
}