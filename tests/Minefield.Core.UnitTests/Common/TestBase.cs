namespace Minefield.Core.UnitTests.Common;

public class TestBase
{
    public IServiceProvider ServiceProvider = null!;

    [OneTimeSetUp]
    public async Task Init()
    {
        ServiceProvider = Fixtures.FixtureFactory.CreateFixture();
    }

    /// <summary>
    /// Code here would be executed before every test.
    /// </summary>
    //[SetUp]
    //public async Task SetUp()
    //{
    //}

    /// <summary>
    /// Code here would be executed after every test.
    /// </summary>
    //[TearDown]
    //public void TearDown()
    //{
    //    //
    //}

    //[OneTimeTearDown]
    // public async Task ClearDown()
    // {
    // DestroyDbAndMocks();
    // }
}