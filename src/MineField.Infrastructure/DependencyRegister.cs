using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIneField.Core.Dependencies;

namespace MineField.Infrastructure;

public static class DependencyRegister
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection @this,
																	IConfigurationRoot configurationManager)
	{
		// Register Internal Services:
		//@this.AddScoped<ICurrentUserService, CurrentUserService>();

		// Register Actual Services:            
		//@this.AddSingleton<IDateTimeProvider, BasicDateTimeProvider>();

		// Register App Settings - from appsettings.json section
		@this.AddSingleton<IGameConfiguration>(SetConfigurationValues(configurationManager));

		return @this;
	}


	private static GameConfiguration SetConfigurationValues(IConfigurationRoot configurationManager)
	{
		GameConfiguration settings = new();
		configurationManager.GetSection("GameConfiguration").Bind(settings);

		if (!settings.IsValid())
			throw new ApplicationException("Settings Invalid");

		return settings;
	}
}
