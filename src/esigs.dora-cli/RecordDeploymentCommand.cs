using System;
using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using esigs.dora.iface; // Assuming this namespace is available from the NuGet package

namespace esigs.dora_cli
{
    public sealed class RecordDeploymentCommand : Command<RecordDeploymentCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-t|--timestamp <TIMESTAMP>")]
            [Description("The timestamp of the deployment (e.g., '2023-01-15T10:30:00Z').")]
            public DateTime Timestamp { get; set; }

            [CommandOption("-s|--success <SUCCESS>")]
            [Description("Indicates whether the deployment was successful (true/false).")]
            public bool Success { get; set; }

            [CommandOption("-l|--lead-time <LEAD_TIME>")]
            [Description("The lead time for the change associated with this deployment (e.g., '0.01:00:00' for 1 hour).")]
            public TimeSpan LeadTime { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            // Placeholder for IDoraMetricsTracker instance.
            // In a real application, this would be injected or resolved from a container.
            IDoraMetricsTracker metricsTracker = Program.MetricsTracker;

            if (metricsTracker == null)
            {
                AnsiConsole.MarkupLine("[red]Error: IDoraMetricsTracker instance not available.[/]");
                return -1;
            }

            var result = metricsTracker.RecordDeployment(settings.Timestamp, settings.Success, settings.LeadTime);

            if (result.IsSuccess)
            {
                AnsiConsole.MarkupLine("[green]Deployment recorded successfully.[/]");
                return 0;
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Error recording deployment: {result.Error}[/]");
                return -1;
            }
        }
    }
}
