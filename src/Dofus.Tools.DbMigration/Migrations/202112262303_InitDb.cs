using FluentMigrator;

namespace Practice.DbMigration.Migrations
{
    [Migration(202112262303)]
    public class InitDb : Migration
    {
        public override void Up()
        {
            Execute.Script("InstallExtension.sql");

            Create.Table("prices")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("dofus_id").AsInt64().Indexed()
                .WithColumn("server_id").AsInt16().NotNullable().Indexed()
                .WithColumn("value").AsInt64().NotNullable()
                .WithColumn("created_at").AsDateTimeOffset().NotNullable().Indexed()
                .WithColumn("created_by").AsString().NotNullable().Indexed();
        }

        public override void Down()
        {
            Delete.Table("prices");
        }
    }
}