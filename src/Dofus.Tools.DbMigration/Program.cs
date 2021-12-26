using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Practice.DbMigration.Migrations;

namespace Dofus.Hdv.DbMigration
{
    internal class Program
    {
        private static void Main()
        {
            var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        ///     Configure the dependency injection services.
        /// </summary>
        private static IServiceProvider CreateServices() => new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(Environment.GetEnvironmentVariable("ConnectionStrings__PracticeDatabase"))
                .ScanIn(typeof(InitDb).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        /// <summary>
        ///     Update the database.
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}