using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Infrastructure.Data;

namespace Municorn.TestApp.IntegrationTests.Data;

public abstract class RepoTestFixture
{
    protected AppDbContext _dbContext;

    protected RepoTestFixture()
    {
        var options = CreateNewContextOptions();

        _dbContext = new AppDbContext(options);
    }

    protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseInMemoryDatabase("integrationTests")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }
}
