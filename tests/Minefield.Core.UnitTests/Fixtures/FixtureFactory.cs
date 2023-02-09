using Microsoft.Extensions.DependencyInjection;
using MineField.Core;
using MineField.Core.Dependencies;

namespace Minefield.Core.UnitTests.Fixtures;

/// <summary>
/// Helper class that allows for easy creation of unit/integration test fixtures.
/// </summary>
internal static class FixtureFactory
{
    public static IServiceProvider CreateFixture(Action<IServiceCollection> serviceCollectionAppendDelegate = default)
    {
        var serviceProvider = GetBaseServiceCollection()
            .AddAppendDelegate(serviceCollectionAppendDelegate)
            .BuildServiceProvider();

        return serviceProvider;
    }

    private static IServiceCollection AddAppendDelegate(this IServiceCollection serviceCollection, Action<IServiceCollection> serviceCollectionAppendDelegate)
    {
        serviceCollectionAppendDelegate?.Invoke(serviceCollection);
        return serviceCollection;
    }

    private static IServiceCollection GetBaseServiceCollection()
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton(s => Mock.Of<IGameConfiguration>(t => t.Lives == 3 && t.NoOfMines == 20)) // need to default lives && NoOfMines
                                                                                                    //.AddSingleton(s => SetupMockConfig()) 
            .AddCore(); //IMineGenerator mineGenerator setup here !!

        return serviceCollection;
    }

    //private static Mock<IGameConfiguration> SetupMockConfig()
    //{
    //    var userMock = new Mock<IGameConfiguration>().SetupAllProperties();

    //    SetPropertiesOfUser(userMock.Object);

    //    return userMock;
    //}

    //private static void SetPropertiesOfUser(IGameConfiguration config)
    //{
    //    config.Lives = 3;
    //    config.NoOfMines = 20;
    //}
}