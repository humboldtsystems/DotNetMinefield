using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineField.Core;
using MineField.Core.Dependencies;
using MineField.Core.Entities;
using MineField.Infrastructure;
using System.Reflection;

namespace Minefield.Game;

internal static class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static ServiceProvider ServiceProvider { get; set; }

    static void Main()
    {
        var services = ConfigureServices();
        ServiceProvider = services.BuildServiceProvider();

        var gameService = ServiceProvider.GetService<IGameService>();
        gameService!.InformPlayerTriggered += (obj, eventARgs) => Console.WriteLine(eventARgs.Message);

        Console.WriteLine("Welcome");

        Console.WriteLine("Select your first move by pressing any arrow key");

        while (!gameService.GameOver)
        {
            var key = Console.ReadKey(false).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    gameService!.Move(MovementDirection.Up);
                    break;

                case ConsoleKey.DownArrow:
                    gameService!.Move(MovementDirection.Down);
                    break;

                case ConsoleKey.LeftArrow:
                    gameService!.Move(MovementDirection.Left);
                    break;

                case ConsoleKey.RightArrow:
                    gameService!.Move(MovementDirection.Right);
                    break;
            }
        }
    }

    private static IServiceCollection ConfigureServices()
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());

        builder.AddJsonFile("appsettings.json", optional: false);

#if DEBUG
        {
            try
            {
                builder.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
            }
            catch
            {
                // This exception only happens if the `UserSecretsId` property does not exist in the .csproj file.
            }
        }
#endif

        Configuration = builder.Build();

        IServiceCollection services = new ServiceCollection();
        services.AddCore();
        services.AddInfrastructure(Configuration);

        return services;
    }
}
