using Microsoft.Extensions.DependencyInjection;
using MineField.Core.Dependencies;
using MineField.Core.Services;

namespace MineField.Core;

public static class DependencyRegister
{
    public static IServiceCollection AddCore(this IServiceCollection @this)
    {
        @this.AddTransient<IGameService, GameService>();
        @this.AddTransient<IMineGenerator, MineGenerator>();
        //@this.AddTransient<MinefieldApp>();

        return @this;
    }
}
