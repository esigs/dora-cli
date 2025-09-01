using System.Reflection;
using Spectre.Console.Cli;
using Spectre.Console;

namespace esigs.dora_cli
{
    public sealed class VersionCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            if (version != null)
            {
                AnsiConsole.MarkupLine($"[green]dora-cli version:[/] [yellow]{version}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Version information not available.[/]");
            }
            return 0;
        }
    }
}