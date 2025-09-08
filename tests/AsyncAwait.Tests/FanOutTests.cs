using AsyncAwait.Playbook.Common;
using AsyncAwait.Playbook.Pitfalls;
using FluentAssertions;

namespace AsyncAwait.Tests;

public class FanOutTests
{
    [Fact]
    public async Task WhenAll_Is_Faster_Than_Sequential()
    {
        var svc = new FakeDelayService();
        var calls = Enumerable.Range(0, 3)
            .Select(i => (Func<Task<string>>)(() => svc.DelayReturnAsync(i.ToString(), TimeSpan.FromMilliseconds(250))));

        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        await PoorFanOut.Bad_SequentialAsync(calls);
        sw1.Stop();

        var sw2 = System.Diagnostics.Stopwatch.StartNew();
        await PoorFanOut.Good_WhenAllAsync(calls);
        sw2.Stop();

        sw2.Elapsed.Should().BeLessThan(sw1.Elapsed);
        sw1.Elapsed.Should().BeGreaterThan(TimeSpan.FromMilliseconds(700)); // ~750ms+
        sw2.Elapsed.Should().BeLessThan(TimeSpan.FromMilliseconds(600));    // ~250-300ms, some slack
    }
}