using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineField.Infrastructure;
using MineField.Core;
using MineField.Core.Dependencies;
using MineField.Core.Entities;
using System.Reflection;

namespace Minefield.Game
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static ServiceProvider ServiceProvider { get; set; }

        static void Main(string[] args)
        {
            var services = ConfigureServices();
            ServiceProvider = services.BuildServiceProvider();

            //Counter c = new Counter();
            //c.Add("blah");
            //c.ThresholdReached += c_InformPlayer;

            var gameService = ServiceProvider.GetService<IGameService>();

            while (true)
            {
                // Intercept to prevent key display.
                var key = Console.ReadKey(false).Key;

                // Call move command when a movement arrow is pressed.
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
                    //Log.Warning("No User Secrets Id Found for the project.");

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

        static void c_InformPlayer(Object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}