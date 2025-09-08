namespace AsyncAwait.Playbook.Common;

public sealed class FakeDelayService : IFakeDelayService
{
    public async Task<string> DelayReturnAsync(string value, TimeSpan delay, CancellationToken ct = default)
    {
        await Task.Delay(delay, ct);
        return value;
    }
}