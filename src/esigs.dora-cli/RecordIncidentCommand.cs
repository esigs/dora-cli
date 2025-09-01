using System;
using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using esigs.dora.iface;

namespace esigs.dora_cli
{
    public sealed class RecordIncidentCommand : Command<RecordIncidentCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-s|--start-time <START_TIME>")]
            [Description("The start time of the incident (e.g., '2023-01-15T10:30:00Z').")]
            public DateTime StartTime { get; set; }

            [CommandOption("-e|--end-time <END_TIME>")]
            [Description("The end time of the incident (e.g., '2023-01-15T11:00:00Z').")]
            public DateTime EndTime { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            IDoraMetricsTracker metricsTracker = Program.MetricsTracker;

            if (metricsTracker == null)
            {
                AnsiConsole.MarkupLine("[red]Error: IDoraMetricsTracker instance not available.[/]");
                return -1;
            }

            var result = metricsTracker.RecordIncident(settings.StartTime, settings.EndTime);

            if (result.IsSuccess)
            {
                AnsiConsole.MarkupLine("[green]Incident recorded successfully.[/]");
                return 0;
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Error recording incident: {result.Error}[/]");
                return -1;
            }
        }
    }
}
