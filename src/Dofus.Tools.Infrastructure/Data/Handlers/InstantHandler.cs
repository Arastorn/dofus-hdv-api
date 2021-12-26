using System.Data;
using Dapper;
using NodaTime;

namespace Dofus.Tools.Infrastructure.Data.Handlers
{
    public class InstantHandler : SqlMapper.TypeHandler<Instant?>
    {
        public override void SetValue(IDbDataParameter parameter, Instant? value)
        {
            parameter.Value = value?.ToDateTimeUtc() ?? (object)DBNull.Value;
            parameter.DbType = DbType.DateTimeOffset;
        }

        public override Instant? Parse(object value) => value switch
        {
            null => null,
            DateTime dateTime => Instant.FromDateTimeUtc(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)),
            DateTimeOffset dateTimeOffset => Instant.FromDateTimeOffset(dateTimeOffset),
            Instant instant => instant,
            _ => throw new DataException("Cannot convert " + value.GetType() + " to NodaTime.Instant")
        };
    }
}