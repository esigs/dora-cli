using Spectre.Console.Cli;
using esigs.dora_cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddCommand<HelloWorldCommand>("hello-world")
          .WithDescription("Prints 'Hello, World!' to the console.");
});

return app.Run(args);