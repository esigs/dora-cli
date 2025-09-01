using Spectre.Console;
using Spectre.Console.Cli;

namespace esigs.dora_cli
{
    public sealed class HelloWorldCommand : Command<HelloWorldCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            // No specific settings needed for this simple command
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            AnsiConsole.WriteLine("Hello, World!");
            return 0;
        }
    }
}
