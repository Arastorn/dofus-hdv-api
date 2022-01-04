using System.Data;
using Autofac;
using Dapper;
using Dofus.Tools.Infrastructure.Data;
using Dofus.Tools.Infrastructure.Data.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Npgsql;

namespace Dofus.Tools.Infrastructure
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            NpgsqlConnection.GlobalTypeMapper.UseJsonNet(settings: new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            SqlMapper.AddTypeHandler(new InstantHandler());

            return services;
        }

        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder, string connectionString)
        {
            builder.Register(c => new PriceRepository(connectionString)).As<Core.Interfaces.PriceRepository>();

            return builder;
        }
    }
}