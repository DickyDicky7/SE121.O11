using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduleReminder.Testing.MockDependencies
{
	public class MockTraceListener : TraceListener
	{
		public MockTraceListener(string? name) : base(name)
		{
		}

		public List<string> DebugOutputs { get; } = new();

		public override void Write(string? message)
		{
			DebugOutputs.Add($"{Environment.CurrentManagedThreadId}: {message ?? string.Empty}");
		}

		public override void WriteLine(string? message)
		{
			DebugOutputs.Add($"{Environment.CurrentManagedThreadId}: {message ?? string.Empty}");
		}
	}
}
