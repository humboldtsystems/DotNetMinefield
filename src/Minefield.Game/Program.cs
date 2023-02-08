using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIneField.Core;
using MineField.Infrastructure;
using MIneField.Core.Entities;
using MIneField.Core.Services;

namespace Minefield.Game
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            Counter c = new Counter();
            c.Add("blah");
            c.ThresholdReached += c_InformPlayer;


            // Loop and read player key entries.
            while (true)
            {
                // Intercept to prevent key display.
                var key = Console.ReadKey(false).Key;

                // Call move command when a movement arrow is pressed.
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        GameService.Move(MovementDirection.Up);
                        break;

                    case ConsoleKey.DownArrow:
                        GameService.Move(MovementDirection.Down);
                        break;

                    case ConsoleKey.LeftArrow:
                        GameService.Move(MovementDirection.Left);
                        break;

                    case ConsoleKey.RightArrow:
                        GameService.Move(MovementDirection.Right);
                        break;
                }
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");

            var config = configuration.Build();

            // Setup dependency injection.
            IServiceCollection services = new ServiceCollection();

            // Register dependencies
            services.AddInfrastructure(config);
            services.AddCore();

            return services;
        }

        static void c_InformPlayer(Object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}