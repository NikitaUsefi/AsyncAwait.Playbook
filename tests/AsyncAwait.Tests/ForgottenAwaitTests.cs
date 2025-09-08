using AsyncAwait.Playbook.Pitfalls;
using FluentAssertions;

namespace AsyncAwait.Tests;

public class ForgottenAwaitTests
{
    [Fact]
    public async Task ContinueWith_Observes_Exception()
    {
        var tcs = new TaskCompletionSource();
        var errorSeen = false;

        ForgottenAwait.Better_FireAndForget(Task.Run(async () =>
        {
            await Task.Delay(10);
            throw new InvalidOperationException("boom");
        }), _ => errorSeen = true);

        // Give continuation time to run
        await Task.Delay(50);
        errorSeen.Should().BeTrue();
    }
}