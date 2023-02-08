using Microsoft.Extensions.DependencyInjection;
using MIneField.Core.Dependencies;
using MIneField.Core.Services;

namespace MIneField.Core;

public static class DependencyRegister
{
	public static IServiceCollection AddCore(this IServiceCollection @this)
	{
        @this.AddTransient<IGameService, GameService>();
        //@this.AddTransient<MinefieldViewModel>();
        //@this.AddTransient<MinefieldApp>();

        return @this;
	}
}
