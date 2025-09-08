\# AsyncAwait.Playbook



A tiny, professional .NET 8 repo that \*\*demonstrates common async/await mistakes\*\* and the \*\*correct patterns\*\*:



\- Pitfalls: `.Result`/`.Wait`, `async void`, sync-over-async, forgetting to `await`, poor fan-out.

\- Patterns: `await` all the way, `Task.WhenAll`, cancellation tokens, HttpClient reuse, and when to use `ConfigureAwait(false)`.



\## Why this repo

I built this as a compact reference I can share with teams and recruiters. Each scenario has a \*\*bad\*\* and \*\*good\*\* example, plus \*\*unit tests\*\* where it makes sense.



\## Quickstart

```bash

dotnet build

dotnet test

dotnet run --project src/AsyncAwait.Demo



\## License

This project is licensed under the MIT License - see the \[LICENSE](./LICENSE) file for details.

