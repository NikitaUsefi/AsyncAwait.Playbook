namespace AsyncAwait.Playbook.Common;

public interface IFakeDelayService
{
    Task<string> DelayReturnAsync(string value, TimeSpan delay, CancellationToken ct = default);
}