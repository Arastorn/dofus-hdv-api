using System.Data;
using Autofac;
using Dapper;
using Dofus.Hdv.Infrastructure.Data;
using Dofus.Hdv.Infrastructure.Data.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Npgsql;

namespace Dofus.Hdv.Infrastructure
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            NpgsqlConnection.GlobalTypeMapper.UseJsonNet(settings: new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddTransient<IDbConnection>(c => new NpgsqlConnection(connectionString));

            SqlMapper.AddTypeHandler(new InstantHandler());

            return services;
        }

        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder)
        {
            builder.RegisterType<PriceRepository>().As<Core.Interfaces.PriceRepository>();

            return builder;
        }
    }
}