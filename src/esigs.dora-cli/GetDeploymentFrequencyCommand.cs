using System;
using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using esigs.dora.iface;

namespace esigs.dora_cli
{
    public sealed class GetDeploymentFrequencyCommand : Command<GetDeploymentFrequencyCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-s|--start-date <START_DATE>")]
            [Description("The start date of the period (e.g., '2023-01-01').")]
            public DateTime StartDate { get; set; }

            [CommandOption("-e|--end-date <END_DATE>")]
            [Description("The end date of the period (e.g., '2023-01-31').")]
            public DateTime EndDate { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            IDoraMetricsTracker metricsTracker = Program.MetricsTracker;

            if (metricsTracker == null)
            {
                AnsiConsole.MarkupLine("[red]Error: IDoraMetricsTracker instance not available.[/]");
                return -1;
            }

            var result = metricsTracker.GetDeploymentFrequency(settings.StartDate, settings.EndDate);

            if (result.IsSuccess)
            {
                AnsiConsole.MarkupLine($"[green]Deployment Frequency: {result.Value}[/]");
                return 0;
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Error getting deployment frequency: {result.Error}[/]");
                return -1;
            }
        }
    }
}
