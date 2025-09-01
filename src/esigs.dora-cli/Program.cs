using Spectre.Console.Cli;
using esigs.dora_cli;
using esigs.dora.iface;
using esigs.dora.lib;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

public static class Program
{
    public static IDoraMetricsTracker MetricsTracker { get; private set; } = new FileBasedDoraMetricsTracker(
        new OptionsWrapper<DoraFileStorageOptions>(new DoraFileStorageOptions { FilePath = ConfigManager.GetDataFilePath() }),
        NullLoggerFactory.Instance.CreateLogger<FileBasedDoraMetricsTracker>());

    public static int Main(string[] args)
    {
        var app = new CommandApp();

        // For demonstration purposes, we'll use a mock implementation.
        // In a real application, you would use a proper dependency injection container
        // to provide the IDoraMetricsTracker instance.
        // MetricsTracker = new MockDoraMetricsTracker(); // Removed this line

        app.Configure(config =>
{
    config.AddCommand<RecordDeploymentCommand>("record-deployment")
          .WithDescription("Records a deployment event.");

    config.AddCommand<RecordIncidentCommand>("record-incident")
          .WithDescription("Records an incident event.");

    config.AddCommand<GetDeploymentFrequencyCommand>("get-deployment-frequency")
          .WithDescription("Gets the deployment frequency for a specified period.");

    config.AddCommand<GetLeadTimeForChangesCommand>("get-lead-time-for-changes")
          .WithDescription("Gets the lead time for changes for a specified period.");

    config.AddCommand<GetChangeFailureRateCommand>("get-change-failure-rate")
          .WithDescription("Gets the change failure rate for a specified period.");

    config.AddCommand<GetMeanTimeToRecoveryCommand>("get-mean-time-to-recovery")
          .WithDescription("Gets the mean time to recovery for a specified period.");

    config.AddCommand<VersionCommand>("version")
          .WithDescription("Displays the application version.");
});

return app.Run(args);
    }
}