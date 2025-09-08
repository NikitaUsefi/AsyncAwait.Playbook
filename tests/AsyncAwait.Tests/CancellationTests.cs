using AsyncAwait.Playbook.Patterns;
using FluentAssertions;

namespace AsyncAwait.Tests;

public class CancellationTests
{
    [Fact]
    public async Task Fetch_Cancels_On_Timeout()
    {
        using var http = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri("https://httpbin.org/") };
        Func<Task> act = async () => await CancellationPattern.FetchWithTimeoutAsync(http, "delay/5", TimeSpan.FromMilliseconds(200));
        await act.Should().ThrowAsync<OperationCanceledException>();
    }
}