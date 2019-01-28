namespace VidlyAppy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreClass : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (name) values ('Comedy')");
            Sql("insert into genres (name) values ('Action')");
            Sql("insert into genres (name) values ('Family')");
            Sql("insert into genres (name) values ('Romance')");

        }

        public override void Down()
        {
        }
    }
}
